using MediatR;

namespace DB_ECommerce.Application.Orders
{
    public class DeleteOrderCommand : IRequest
    {
        public int OrderID { get; set; }
    }
}
