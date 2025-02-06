using MediatR;

namespace DB_ECommerce.Application.Product_Orders
{
    public class CreateProductOrderCommand : IRequest
    {
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
