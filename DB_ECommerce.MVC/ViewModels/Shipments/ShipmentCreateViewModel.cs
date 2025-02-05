namespace DB_ECommerce.MVC.ViewModels.Shipments
{
    public class ShipmentCreateViewModel
    {
        public DateTime? ShipmentDate { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string ShipmentStatus { get; set; }
        public int OrderId { get; set; }
    }
}
