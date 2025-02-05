using MediatR;
using DB_E_Commerce.E_Commerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Orderss
{
    public class GetOrdersQuery : IRequest<List<Order>>
    {
    }
}
