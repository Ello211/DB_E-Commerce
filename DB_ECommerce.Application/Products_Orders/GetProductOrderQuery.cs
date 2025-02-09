using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Product_Orders
{
    public class GetProductOrderQuery : IRequest<Product_Order>
    {
        public int ProductOrderID { get; set; }
    }
}
