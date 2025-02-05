using MediatR;

namespace DB_ECommerce.Application.Shipments;
public class CreateShipmentCommand : IRequest
{

    public DateTime? ShipmentDate { get; set; }

    public string TrackingNumber { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string ShipmentStatus { get; set; }

    public int OrderID { get; set; }

}

