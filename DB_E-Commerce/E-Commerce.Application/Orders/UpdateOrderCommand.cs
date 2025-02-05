using MediatR;
using DB_E_Commerce.E_Commerce.Models;

namespace DB_E_Commerce.E_Commerce.Application.Orderss
{
    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> ProductsOrders { get; set; } = new();

        public Order ToOrder()
        {
            var order = new Order
            {
                OrderID = this.Id,
                CustomerId = this.CustomerId,
                OrderDate = this.OrderDate,
                TotalPrice = this.TotalPrice,
                ProductsOrders = this.ProductsOrders
            };
            return order;
        }
    }
}
