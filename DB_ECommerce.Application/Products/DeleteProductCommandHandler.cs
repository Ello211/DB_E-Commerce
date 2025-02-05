using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Products
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly ECommerceContext context;
        private readonly IDistributedCache cache;

        public DeleteProductCommandHandler(ECommerceContext context, IDistributedCache cache)
        {
            this.context = context;
            this.cache = cache;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(new object[] { request.Id }, cancellationToken);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync(cancellationToken);

            await this.InvalidateCache(product);
        }

        private async Task InvalidateCache(Product product)
        {
            var key = $"product-{product.ProductID}";
            await this.cache.RemoveAsync(key);
        }
    }
}
