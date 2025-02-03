using Microsoft.EntityFrameworkCore;

using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence.Configuration;

namespace DB_E_Commerce.E_Commerce.Persistence
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Products> Products { get; set; }
        /*
        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Mark> Marks { get; set; }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            /*
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new MarkConfiguration());
            */
        }
    }
}
