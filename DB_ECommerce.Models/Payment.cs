namespace DB_ECommerce.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public int OrderID { get; set; }

        public string Currency { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentStatus { get; set; }

        public decimal PaymentAmount { get; set; }

        public decimal OpenPayment { get; set; }

        public Order Order { get; set; }

    }
}