using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Shipments;

public class GetShipmentsListQueryHandler : IRequestHandler<GetShipmentsListQuery, List<Shipment>>
{
    private readonly DB_ECommerceContext context;

    public GetShipmentsListQueryHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task<List<Shipment>> Handle(GetShipmentsListQuery request, CancellationToken cancellationToken)
    {
        var shipments = await context.Shipments
            .Include(shipment => shipment.Order)
            .ToListAsync(cancellationToken);

        return shipments;
    }
}