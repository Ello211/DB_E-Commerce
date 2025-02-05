using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace DB_E_Commerce.E_Commerce.Application.Product_Orders
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
                .FirstOrDefaultAsync(po => po.ProductOrderID == request.ProductId && po.OrderId == request.OrderId, cancellationToken);

            if (productOrder == null)
            {
                throw new KeyNotFoundException($"ProductOrder with ProductId {request.ProductId} and OrderId {request.OrderId} not found.");
            }

            return productOrder;
        }
    }
}
