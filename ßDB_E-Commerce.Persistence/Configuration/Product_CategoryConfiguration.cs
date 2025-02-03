using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_E_Commerce.Models;

namespace DB_E_Commerce.Persistence.Configuration
{
    public class Product_CategoryConfiguration : IEntityTypeConfiguration<Product_Category>
    {
        public void Configure(EntityTypeBuilder<Product_Category> builder)
        {
            builder.Property(product_category => product_category.ProductID).IsRequired();
            builder.Property(product_category => product_category.CategoryID).IsRequired();

            builder.HasOne(product_category => product_category.ProductID)
                .WithOne(product => product.ProductID);

            builder.HasOne(product_category => product_category.CategoryID)
                .WithOne(category => category.CategoryID);

        }
    }
}
