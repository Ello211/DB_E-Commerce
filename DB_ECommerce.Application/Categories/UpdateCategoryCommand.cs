using MediatR;

using DB_ECommerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Categories
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Product_Category> ProductCategories { get; set; } = new();

        public Category ToCategory()
        {
            var category = new Category
            {
                CategoryID = this.Id,
                CategoryName = this.CategoryName
            };
            return category;
        }
    }
}
