using MediatR;

using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Shipments;

public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand>
{
    private readonly DB_ECommerceContext context;

    public DeleteShipmentCommandHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
    {
        var shipment = await context.Shipments.FindAsync(request.ShipmentID, cancellationToken);
        if (shipment != null)
        {
            context.Shipments.Remove(shipment);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}