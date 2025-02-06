namespace DB_ECommerce.MVC.ViewModels.Categories
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // Konvertiert das Model in ein ViewModel
        public static CategoryDetailsViewModel FromCategory(DB_ECommerce.Models.Category category)
        {
            return new CategoryDetailsViewModel
            {
                Id = category.CategoryID,
                CategoryName = category.CategoryName
            };
        }
    }
}
    