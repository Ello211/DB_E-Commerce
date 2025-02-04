namespace DB_ECommerce.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public Customer Customer { get; set; }

        public Payment Payment { get; set; }

        public ICollection<Product_Order> Products_Orders { get; set; }

    }
}
