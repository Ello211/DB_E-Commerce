using MediatR;

namespace DB_ECommerce.Application.Shipments;

public class DeleteShipmentCommand : IRequest
{
    public int ShipmentID { get; set; }
}