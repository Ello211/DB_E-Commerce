using MediatR;

namespace DB_ECommerce.Application.Shipments;
public class UpdateShipmentCommand : IRequest
{
    public int ShipmentID { get; set; }
    public DateTime? ShipmentDate { get; set; }

    public string TrackingNumber { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string ShipmentStatus { get; set; }

    public int OrderID { get; set; }
}

