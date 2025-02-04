using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_ECommerce.Models;

namespace DB_ECommerce.Persistence.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(payment => payment.PaymentID);

            builder.Property(payment => payment.Currency).HasMaxLength(50).IsRequired();
            builder.Property(payment => payment.PaymentMethod).HasMaxLength(50).IsRequired();
            builder.Property(payment => payment.PaymentStatus).HasMaxLength(50).IsRequired();
            builder.Property(payment => payment.PaymentAmount).IsRequired();
            builder.Property(payment => payment.OpenPayment).IsRequired();

            builder.HasOne(payment => payment.Order)
                .WithOne(order => order.Payment);

        }
    }
}
