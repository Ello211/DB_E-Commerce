using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Shipments;

public class GetShipmentQueryHandler : IRequestHandler<GetShipmentQuery, Shipment>
{
    private readonly DB_ECommerceContext context;

    public GetShipmentQueryHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task<Shipment> Handle(GetShipmentQuery request, CancellationToken cancellationToken)
    {
        var shipment = await context.Shipments
            .Include(shipment => shipment.Order)

            .FirstOrDefaultAsync(shipment => shipment.ShipmentID == request.ShipmentID, cancellationToken);

        return shipment;
    }
}