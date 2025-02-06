namespace DB_ECommerce.MVC.ViewModels.Shipments
{
    public class ShipmentDetailsViewModel
    {
        public int ShipmentID { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string ShipmentStatus { get; set; }
        public int OrderId { get; set; }
    }
}
