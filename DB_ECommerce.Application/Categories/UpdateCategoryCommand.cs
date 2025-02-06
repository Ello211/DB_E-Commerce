using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Categories
{
    public class UpdateCategoryCommand : IRequest
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public Category ToCategory()
        {
            var category = new Category
            {
                CategoryID = this.CategoryID,
                CategoryName = this.CategoryName
            };
            return category;
        }
    }
}
