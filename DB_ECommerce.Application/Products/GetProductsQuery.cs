using MediatR;
using DB_ECommerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Products
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
    }
}