namespace DB_ECommerce.MVC.ViewModels.Products
{
    public class ProductListViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public double? AverageRating { get; set; }

        public static ProductListViewModel FromProduct(DB_ECommerce.Models.Product product, double? averageRating = null)
        {
            return new ProductListViewModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price,
                AverageRating = averageRating
            };
        }
    }
}

