using MediatR;
using DB_E_Commerce.E_Commerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Categories
{
    public class GetCategoryQuery : IRequest<Category>
    {
        public int Id { get; set; }
    }
}


