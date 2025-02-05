using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Shipments;

public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommand>
{
    private readonly DB_ECommerceContext context;

    public UpdateShipmentCommandHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
    {
        var existingShipment = await context.Shipments
            .Include(shipemnt => shipemnt.Order)
            .FirstOrDefaultAsync(shipemnt => shipemnt.ShipmentID == request.ShipmentID, cancellationToken);

        if (existingShipment == null)
        {
            throw new NullReferenceException("Shipment not found");
        }

        var order = await context.Orders.FirstOrDefaultAsync(o => o.OrderID == request.OrderID, cancellationToken);
        if (order == null)
        {
            throw new NullReferenceException("Order not found");
        }

        existingShipment.ShipmentDate = request.ShipmentDate;
        existingShipment.TrackingNumber = request.TrackingNumber;
        existingShipment.DeliveryDate = request.DeliveryDate;
        existingShipment.ShipmentStatus = request.ShipmentStatus;
        existingShipment.Order = order;

        await context.SaveChangesAsync(cancellationToken);
    }
}