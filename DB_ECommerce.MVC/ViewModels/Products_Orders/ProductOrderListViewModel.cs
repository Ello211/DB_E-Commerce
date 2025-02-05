using DB_ECommerce.Models;

namespace DB_ECommerce.MVC.ViewModels.Products_Orders
{
    public class ProductOrderListViewModel
    {
        public int ProductOrderID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public static ProductOrderListViewModel FromProductOrder(Product_Order productOrder)
        {
            return new ProductOrderListViewModel
            {
                ProductOrderID = productOrder.ProductOrderID,
                ProductName = productOrder.Product.ProductName,
                Quantity = productOrder.Quantity,
                TotalPrice = productOrder.TotalPrice
            };
        }
    }
}
