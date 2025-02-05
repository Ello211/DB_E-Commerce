namespace DB_ECommerce.MVC.ViewModels.Products
{
    public class ProductUpdateViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        // Kategorien, die bearbeitet werden können
        public List<int> SelectedCategoryIds { get; set; } = new List<int>();

        public static ProductUpdateViewModel FromProduct(DB_ECommerce.Models.Product product)
        {
            return new ProductUpdateViewModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price,
                SelectedCategoryIds = product.Products_Categories.Select(pc => pc.CategoryID).ToList()
            };
        }
    }
}
