using MediatR;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Products
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
    }
}