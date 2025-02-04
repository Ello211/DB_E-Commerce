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

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new MarkConfiguration());
        }
    }
}
