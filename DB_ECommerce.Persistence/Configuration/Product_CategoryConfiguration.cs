using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_ECommerce.Models;

namespace DB_ECommerce.Persistence.Configuration
{
    public class Product_CategoryConfiguration : IEntityTypeConfiguration<Product_Category>
    {
        public void Configure(EntityTypeBuilder<Product_Category> builder)
        {

            builder.HasOne(product_category => product_category.Category)
                .WithMany(category => category.Products_Categories);

            builder.HasOne(product_category => product_category.Product)
                .WithMany(product => product.Products_Categories);
        }
    }
}
