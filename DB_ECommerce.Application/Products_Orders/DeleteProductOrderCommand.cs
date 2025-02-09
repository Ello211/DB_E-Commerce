using MediatR;

namespace DB_ECommerce.Application.Product_Orders
{
    public class DeleteProductOrderCommand : IRequest
    {
        public int ProductOrderID { get; set; }
    }
}
