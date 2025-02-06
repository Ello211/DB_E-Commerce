using MediatR;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Orders
{
    public class GetOrderQuery : IRequest<Order>
    {
        public int OrderID { get; set; }
    }
}
