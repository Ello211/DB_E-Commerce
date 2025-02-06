using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;


namespace DB_ECommerce.Application.Product_Orders
{
    public class GetProductOrderQueryHandler : IRequestHandler<GetProductOrderQuery, Product_Order>
    {
        private readonly DB_ECommerceContext context;

        public GetProductOrderQueryHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<Product_Order> Handle(GetProductOrderQuery request, CancellationToken cancellationToken)
        {
            var productOrder = await context.Products_Orders
                .Include(productOrder => productOrder.Order)
                .Include(productOrder => productOrder.Product)
                .FirstOrDefaultAsync(productOrder => productOrder.ProductOrderID == request.ProductOrderID, cancellationToken);

            if (productOrder == null)
            {
                throw new KeyNotFoundException($"Product_Order with ProductOrderID {request.ProductOrderID} not found.");
            }

            return productOrder;
        }
    }
}
