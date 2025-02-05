using MediatR;
using DB_ECommerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Orderss
{
    public class GetOrdersQuery : IRequest<List<Order>>
    {
    }
}
