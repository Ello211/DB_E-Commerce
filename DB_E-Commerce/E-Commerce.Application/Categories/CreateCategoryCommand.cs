using MediatR;
using DB_E_Commerce.E_Commerce.Models;

namespace DB_E_Commerce.Application.Categories
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
