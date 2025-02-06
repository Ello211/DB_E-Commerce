using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DB_E_Commerce.E_Commerce.Application.Product_Orders
{
    public class GetProductsOrdersQueryHandler : IRequestHandler<GetProductsOrdersQuery, List<Product_Order>>
    {
        private readonly DB_ECommerceContext context;

        public GetProductsOrdersQueryHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Product_Order>> Handle(GetProductsOrdersQuery request, CancellationToken cancellationToken)
        {
            var productOrders = await context.Products_Orders.ToListAsync(cancellationToken);

            if (productOrders == null || productOrders.Count == 0)
            {
                throw new KeyNotFoundException("No ProductOrders found.");
            }

            return productOrders;
        }
    }
}
