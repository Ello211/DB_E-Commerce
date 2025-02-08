using MediatR;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Categories
{
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public string CategoryName { get; set; }

        public Category ToCategory()
        {
            return new Category
            {
                CategoryName = this.CategoryName
            };
        }
    }
}
