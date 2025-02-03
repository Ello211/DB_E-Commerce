using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_E_Commerce.Models;

namespace DB_E_Commerce.Persistence.Configuration
{
    public class Product_OrderConfiguration : IEntityTypeConfiguration<Product_Order>
    {
        public void Configure(EntityTypeBuilder<Product_Order> builder)
        {
            builder.Property(product_order => product_order.OrderID).IsRequired();
            builder.Property(product_order => product_order.ProductID).IsRequired();

            builder.HasOne(product_order => product_order.OrderID)
                .WithOne(order => order.OrderID);

            builder.HasOne(product_order => product_order.ProductID)
                .WithOne(product => product.ProductID);

        }
    }
}
