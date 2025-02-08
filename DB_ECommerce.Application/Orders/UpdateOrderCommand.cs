using MediatR;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Orders
{
    public class UpdateOrderCommand : IRequest
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerID { get; set; }

    }
}