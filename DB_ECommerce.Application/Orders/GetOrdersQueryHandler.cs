using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_ECommerce.Models;
using DB_E_Commerce.E_Commerce.Application.Orderss;
using DB_ECommerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Orderss
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<Order>>
    {
        private readonly DB_ECommerceContext context;

        public GetOrdersQueryHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await context.Orders.ToListAsync(cancellationToken);
            return orders;
        }
    }
}