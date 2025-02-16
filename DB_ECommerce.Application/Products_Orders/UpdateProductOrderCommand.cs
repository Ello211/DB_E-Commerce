using MediatR;

namespace DB_ECommerce.Application.Product_Orders
{
    public class UpdateProductOrderCommand : IRequest
    {
        public int ProductOrderID { get; set; }
        public int Quantity { get; set; }
    }
}
