using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Shipments;

public class GetShipmentQuery : IRequest<Shipment>
{
    public int ShipmentID { get; set; }
}