namespace DB_ECommerce.Models
{
    public class Product_Order
    {
        public int ProductOrderID { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

    }
}
