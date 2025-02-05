using MediatR;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB_E_Commerce.E_Commerce.Application.Product_Orders
{
    public class DeleteProductOrderCommandHandler : IRequestHandler<DeleteProductOrderCommand>
    {
        private readonly ECommerceContext context;

        public DeleteProductOrderCommandHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(DeleteProductOrderCommand request, CancellationToken cancellationToken)
        {
            var productOrder = await context.ProductOrders
                .FirstOrDefaultAsync(po => po.ProductId == request.ProductId && po.OrderId == request.OrderId, cancellationToken);

            if (productOrder == null)
            {
                throw new KeyNotFoundException($"ProductOrder with ProductId {request.ProductId} and OrderId {request.OrderId} not found.");
            }

            context.ProductOrders.Remove(productOrder);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
