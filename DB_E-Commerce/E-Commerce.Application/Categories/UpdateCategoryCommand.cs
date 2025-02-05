using MediatR;

using DB_E_Commerce.E_Commerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Categories
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<ProductCategory> ProductCategories { get; set; } = new();

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
