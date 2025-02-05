using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace DB_E_Commerce.E_Commerce.Application.Product_Orders
{
    public class UpdateProductOrderCommandHandler : IRequestHandler<UpdateProductOrderCommand>
    {
        private readonly ECommerceContext context;

        public UpdateProductOrderCommandHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateProductOrderCommand request, CancellationToken cancellationToken)
        {
            var productOrder = await context.ProductOrders
                .FirstOrDefaultAsync(po => po.ProductId == request.ProductId && po.OrderId == request.OrderId, cancellationToken);

            if (productOrder == null)
            {
                throw new KeyNotFoundException($"ProductOrder with ProductId {request.ProductId} and OrderId {request.OrderId} not found.");
            }

            productOrder.Quantity = request.Quantity;
            productOrder.TotalPrice = productOrder.Quantity * (await context.Products.FirstOrDefaultAsync(p => p.ProductID == request.ProductId, cancellationToken)).Price;

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
