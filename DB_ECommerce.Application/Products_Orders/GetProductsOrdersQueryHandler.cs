using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;


namespace DB_ECommerce.Application.Product_Orders
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
            var productsOrders = await context.Products_Orders
                .Include(productsOrders => productsOrders.Order)
                .Include(productsOrders => productsOrders.Product)
                .ToListAsync(cancellationToken);

            if (productsOrders == null || productsOrders.Count == 0)
            {
                throw new KeyNotFoundException("No Products_Orders found.");
            }

            return productsOrders;
        }
    }
}
