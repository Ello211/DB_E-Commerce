namespace DB_E_Commerce.Models
{
    public class Shipment
    {
        public int ShipmentID { get; set; }

        public DateTime? ShipmentDate { get; set; }

        public string TrackingNumber { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public ICollection<OrderID> Orders { get; set; }

    }
}