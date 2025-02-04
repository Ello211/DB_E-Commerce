namespace DB_ECommerce.Models
{
    public class Shipment
    {
        public int ShipmentID { get; set; }

        public DateTime? ShipmentDate { get; set; }

        public string TrackingNumber { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string ShipmentStatus { get; set; }

        public Order Order { get; set; }

    }
}