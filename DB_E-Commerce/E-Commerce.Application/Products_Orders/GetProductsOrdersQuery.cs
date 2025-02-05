using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Product_Orders
{
    public class GetProductsOrdersQuery : IRequest<List<ProductOrder>>
    {
    }
}
