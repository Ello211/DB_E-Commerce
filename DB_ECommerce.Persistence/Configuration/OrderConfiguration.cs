using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_ECommerce.Models;

namespace DB_ECommerce.Persistence.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.OrderID);

            builder.Property(order => order.OrderDate).IsRequired();
            builder.Property(order => order.TotalPrice).IsRequired();

            builder.HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders);

            builder.HasOne(order => order.Payment)
                .WithOne(payment => payment.Order)
                .HasForeignKey<Payment>(payment => payment.OrderID)
                .IsRequired(false) // Order can exist without a Payment
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
