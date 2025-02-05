using MediatR;
using DB_ECommerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Orderss
{
    public class GetOrderQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
