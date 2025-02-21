using Microsoft.EntityFrameworkCore;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence.Configuration;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DB_ECommerce.Persistence
{
    public class DB_ECommerceContext : DbContext
    {

        private readonly IMongoDatabase _mongoDatabase;

        public DB_ECommerceContext(DbContextOptions<DB_ECommerceContext> options, IOptions<MongoDbSettings> mongoSettings) : base(options)
        {
            // Entferne EnsureCreated, falls du Migrations nutzt!
            // this.Database.EnsureCreated();

            // Initialize MongoDB Client
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            _mongoDatabase = client.GetDatabase(mongoSettings.Value.DatabaseName);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Order> Products_Orders { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

        // Add MongoDB Collection Access
        public IMongoCollection<Review> Reviews => _mongoDatabase.GetCollection<Review>("Reviews");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Lade alle anderen Konfigurationen
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new Product_OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
