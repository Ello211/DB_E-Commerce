namespace DB_ECommerce.MVC.ViewModels.Payments
{
    public class PaymentListViewModel
    {
        public int PaymentID { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal OpenPayment { get; set; }
    }
}
