using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace DB_E_Commerce.E_Commerce.Application.Product_Orders
{
    public class UpdateProductOrderCommandHandler : IRequestHandler<UpdateProductOrderCommand>
    {
        private readonly DB_ECommerceContext context;

        public UpdateProductOrderCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateProductOrderCommand request, CancellationToken cancellationToken)
        {
            var productOrder = await context.Products_Orders
                .FirstOrDefaultAsync(po => po.ProductOrderID == request.ProductId && po.OrderId == request.OrderId, cancellationToken);

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
