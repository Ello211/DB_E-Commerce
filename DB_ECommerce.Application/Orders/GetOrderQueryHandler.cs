using MediatR;
using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Orders
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
            var order = await context.Orders
               .Include(o => o.Customer) 
               .Include(o => o.Payment)   
               .FirstOrDefaultAsync(o => o.OrderID == request.OrderID, cancellationToken);

            if (order == null)
            {
                throw new KeyNotFoundException($"Order with OrderID {request.OrderID} not found.");
            }

            return order;
        }
    }
}