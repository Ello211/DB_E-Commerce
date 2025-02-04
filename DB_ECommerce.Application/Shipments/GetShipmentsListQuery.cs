using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Shipments;

public class GetShipmentsListQuery : IRequest<List<Shipment>>
{
}
