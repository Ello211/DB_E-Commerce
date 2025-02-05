namespace DB_ECommerce.MVC.ViewModels.Categories
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // Diese Methode wandelt das Model in ein ViewModel um
        public static CategoryListViewModel FromCategory(DB_E_Commerce.Models.Category category)
        {
            return new CategoryListViewModel
            {
                Id = category.CategoryID,
                CategoryName = category.CategoryName
            };
        }
    }
}
