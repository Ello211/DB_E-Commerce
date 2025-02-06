using MediatR;

using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Product_Orders
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
            var productOrder = await context.Products_Orders.FindAsync(request.ProductOrderID, cancellationToken);
            if (productOrder == null)
            {
                throw new KeyNotFoundException($"ProductOrder with ProductOrderID {request.ProductOrderID} not found.");
            }

            context.Products_Orders.Remove(productOrder);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
