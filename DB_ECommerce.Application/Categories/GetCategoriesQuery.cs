using MediatR;
using DB_E_Commerce.E_Commerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Categories
{
    public class GetCategoriesQuery : IRequest<List<Category>>
    {

    }
}
