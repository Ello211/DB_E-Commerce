using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_E_Commerce.Models;

namespace DB_E_Commerce.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.ProductID);

            builder.Property(product => product.Productname).HasMaxLength(50).IsRequired();
            builder.Property(product => product.Price).IsRequired();

            builder.HasOne(product => product.CategoryID) 
                .WithOne( product_category => product_category.ProductID);

            builder.HasMany(product => product.OrderIDs) 
                .WithOne(product_order => product_order.ProductID);

        }
    }
}
