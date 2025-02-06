using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_ECommerce.Models;

namespace DB_ECommerce.Persistence.Configuration
{
    public class Product_OrderConfiguration : IEntityTypeConfiguration<Product_Order>
    {
        public void Configure(EntityTypeBuilder<Product_Order> builder)
        {
            builder.HasKey(product_order => product_order.ProductOrderID);

            builder.Property(product_order => product_order.Quantity).IsRequired();
            builder.Property(product_order => product_order.TotalPrice).IsRequired();

            builder.HasOne(product_order => product_order.Order)
                .WithMany(order => order.Products_Orders);

            builder.HasOne(product_order => product_order.Product)
                .WithMany(product => product.Products_Orders);
        }
    }
}
