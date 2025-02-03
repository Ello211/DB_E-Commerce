namespace DB_E_Commerce.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public string Currency { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentStatus { get; set; }

        public decimal PaymentAmount { get; set; }


        public ICollection<OrderID> Orders { get; set; }

    }
}