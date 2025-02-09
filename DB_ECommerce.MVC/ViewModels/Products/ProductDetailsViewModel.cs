using DB_ECommerce.Models;

namespace DB_ECommerce.MVC.ViewModels.Products
{
    public class ProductDetailsViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        // Anzeigen der zugehörigen Kategorien und Bestellungen
        public List<string> Categories { get; set; }
        public List<int> OrderIds { get; set; }

        public static ProductDetailsViewModel FromProduct(Product product)
        {
            return new ProductDetailsViewModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price,
                OrderIds = product.Products_Orders.Select(po => po.ProductOrderID).ToList()
            };
        }
    }
}

