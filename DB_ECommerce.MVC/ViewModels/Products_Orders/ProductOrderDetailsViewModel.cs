using DB_ECommerce.Models;

namespace DB_ECommerce.MVC.ViewModels.Products_Orders
{
    public class ProductOrderDetailsViewModel
    {
        public int ProductOrderID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderNumber { get; set; }

        public static ProductOrderDetailsViewModel FromProductOrder(Product_Order productOrder)
        {
            return new ProductOrderDetailsViewModel
            {
                ProductOrderID = productOrder.ProductOrderID,
                ProductName = productOrder.Product.ProductName,
                Quantity = productOrder.Quantity,
                TotalPrice = productOrder.TotalPrice,
                OrderNumber = productOrder.Order.OrderID.ToString()
            };
        }
    }
}
