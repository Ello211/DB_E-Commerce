using MediatR;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Orders
{
    public class GetOrdersQuery : IRequest<List<Order>>
    {
    }
}
