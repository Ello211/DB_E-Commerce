using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence.Configuration;

namespace DB_ECommerce.Persistence
{
    public class DB_ECommerceContext : DbContext
    {
        public DB_ECommerceContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Product_Category> Products_Categories { get; set; }

        public DbSet<Product_Order> Products_Orders { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new Product_CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new Product_OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentConfiguration());
        }
    }
}
