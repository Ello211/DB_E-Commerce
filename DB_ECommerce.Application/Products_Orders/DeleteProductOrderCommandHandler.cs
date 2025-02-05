using MediatR;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB_E_Commerce.E_Commerce.Application.Product_Orders
{
    public class DeleteProductOrderCommandHandler : IRequestHandler<DeleteProductOrderCommand>
    {
        private readonly DB_ECommerceContext context;

        public DeleteProductOrderCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(DeleteProductOrderCommand request, CancellationToken cancellationToken)
        {
            var productOrder = await context.Products_Orders
                .FirstOrDefaultAsync(po => po.ProductOrderID == request.ProductId && po.OrderId == request.OrderId, cancellationToken);

            if (productOrder == null)
            {
                throw new KeyNotFoundException($"ProductOrder with ProductId {request.ProductId} and OrderId {request.OrderId} not found.");
            }

            context.Products_Orders.Remove(productOrder);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
