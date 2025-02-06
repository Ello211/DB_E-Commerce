using System.ComponentModel.DataAnnotations;
using DB_E_Commerce.Application.Categories;

namespace DB_ECommerce.MVC.ViewModels.Categories
{
    public class CategoryCreateViewModel
    {
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        // Diese Methode wandelt das ViewModel in einen Command um
        public CreateCategoryCommand ToCreateCategoryCommand()
        {
            return new CreateCategoryCommand
            {
                CategoryName = this.CategoryName
            };
        }
    }
}
