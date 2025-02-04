using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Shipments;

public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand>
{
    private readonly DB_ECommerceContext context;

    public CreateShipmentCommandHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FirstOrDefaultAsync(o => o.OrderID == request.OrderID, cancellationToken);
        if (order == null)
        {
            throw new NullReferenceException("Order not found");
        }

        var shipment = new Shipment
        {
            ShipmentDate = request.ShipmentDate,
            TrackingNumber = request.TrackingNumber,
            DeliveryDate = request.DeliveryDate,
            ShipmentStatus = request.ShipmentStatus,
            Order = order
        };

        context.Add(order);
        await context.SaveChangesAsync(cancellationToken);
    }
}