namespace DB_ECommerce.MVC.ViewModels.Shipments
{
    public class ShipmentListViewModel
    {
        public int ShipmentID { get; set; }
        public string TrackingNumber { get; set; }
        public string ShipmentStatus { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
