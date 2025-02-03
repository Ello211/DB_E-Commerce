using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_E_Commerce.Models;

namespace DB_E_Commerce.Persistence.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.OrderID);

            builder.Property(order => order.OrderDate).IsRequired();
            builder.Property(order => order.TotalPrice).IsRequired();

            builder.HasOne(order => order.ProductIDs)
                .WithOne(product_order => product_order.OrderID);

        }
    }
}
