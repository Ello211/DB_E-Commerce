using System.ComponentModel.DataAnnotations;
using DB_E_Commerce.E_Commerce.Application.Categories;

namespace DB_ECommerce.MVC.ViewModels.Categories
{
    public class CategoryUpdateViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        // Konvertiert das Model in ein ViewModel
        public static CategoryUpdateViewModel FromCategory(DB_ECommerce.Models.Category category)
        {
            return new CategoryUpdateViewModel
            {
                Id = category.CategoryID,
                CategoryName = category.CategoryName
            };
        }

        // Wandelt das ViewModel in einen Update-Command um
        public UpdateCategoryCommand ToUpdateCategoryCommand()
        {
            return new UpdateCategoryCommand
            {
                Id = this.Id,
                CategoryName = this.CategoryName
            };
        }
    }
}

