using System.ComponentModel.DataAnnotations;

namespace DB_ECommerce.MVC.ViewModels.ProductCategories
{
    public class ProductCategoryCreateViewModel
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        public int CategoryID { get; set; }
    }
}

