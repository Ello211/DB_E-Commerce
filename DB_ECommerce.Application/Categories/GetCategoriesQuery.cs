using MediatR;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Categories
{
    public class GetCategoriesQuery : IRequest<List<Category>>
    {

    }
}
