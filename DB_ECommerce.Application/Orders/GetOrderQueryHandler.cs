using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_ECommerce.Models;
using DB_E_Commerce.E_Commerce.Application.Orderss;
using DB_ECommerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Orderss
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Order>
    {
        private readonly DB_ECommerceContext context;

        public GetOrderQueryHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.OrderID == request.Id, cancellationToken);

            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {request.Id} not found.");
            }

            return order;
        }
    }
}