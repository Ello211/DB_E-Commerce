namespace DB_ECommerce.MVC.ViewModels.Products
{
    public class ProductCreateViewModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        // Optional: Liste von Kategorien, falls du bei der Erstellung eine Kategorie zuweisen möchtest
        public List<int> SelectedCategoryIds { get; set; } = new List<int>();
    }
}
