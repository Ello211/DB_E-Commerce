using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_ECommerce.Models;

namespace DB_ECommerce.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.ProductID);

            builder.Property(product => product.ProductName).HasMaxLength(50).IsRequired();
            builder.Property(product => product.Price).IsRequired();
        }
    }
}
