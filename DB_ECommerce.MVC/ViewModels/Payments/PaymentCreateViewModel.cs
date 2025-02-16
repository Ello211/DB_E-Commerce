namespace DB_ECommerce.MVC.ViewModels.Payments
{
    public class PaymentCreateViewModel
    {
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal OpenPayment { get; set; }
        public int OrderID { get; set; }
    }
}
