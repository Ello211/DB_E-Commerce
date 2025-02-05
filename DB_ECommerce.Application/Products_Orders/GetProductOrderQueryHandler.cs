using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace DB_E_Commerce.E_Commerce.Application.Product_Orders
{
    public class GetProductOrderQueryHandler : IRequestHandler<GetProductOrderQuery, ProductOrder>
    {
        private readonly ECommerceContext context;

        public GetProductOrderQueryHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<ProductOrder> Handle(GetProductOrderQuery request, CancellationToken cancellationToken)
        {
            var productOrder = await context.ProductOrders
                .FirstOrDefaultAsync(po => po.ProductId == request.ProductId && po.OrderId == request.OrderId, cancellationToken);

            if (productOrder == null)
            {
                throw new KeyNotFoundException($"ProductOrder with ProductId {request.ProductId} and OrderId {request.OrderId} not found.");
            }

            return productOrder;
        }
    }
}
