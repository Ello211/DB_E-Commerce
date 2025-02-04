using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DB_ECommerce.Models;

namespace DB_ECommerce.Persistence.Configuration
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(shipment => shipment.ShipmentID);

            builder.Property(payment => payment.ShipmentDate).IsRequired();
            builder.Property(payment => payment.TrackingNumber).HasMaxLength(50).IsRequired();
            builder.Property(payment => payment.DeliveryDate).IsRequired();
            builder.Property(payment => payment.ShipmentStatus).HasMaxLength(50).IsRequired();

            builder.HasOne(payment => payment.Order)
                .WithMany(order => order.Shipments);

        }
    }
}
