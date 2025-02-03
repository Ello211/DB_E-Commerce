namespace DB_E_Commerce.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public int CustomerID { get; set; }

    }
}
