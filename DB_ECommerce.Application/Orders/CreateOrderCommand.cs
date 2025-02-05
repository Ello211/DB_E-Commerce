using MediatR;
using DB_ECommerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Orderss
{
    public class CreateOrderCommand : IRequest
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> ProductsOrders { get; set; } = new();

        public Order ToOrder()
        {
            var order = new Order
            {
                CustomerId = this.CustomerId,
                OrderDate = this.OrderDate,
                TotalPrice = this.TotalPrice,
                OrderItems = this.ProductsOrders 
            };
            return order;
        }
    }
}
