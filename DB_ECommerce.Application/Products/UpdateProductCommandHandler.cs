using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace DB_ECommerce.Application.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly DB_ECommerceContext context;
        private readonly IDistributedCache cache;

        public UpdateProductCommandHandler(DB_ECommerceContext context, IDistributedCache cache)
        {
            this.context = context;
            this.cache = cache;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // Find the existing product in the database
            var existingProduct = await context.Products.FindAsync(new object[] { request.ProductID }, cancellationToken);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ProductID {request.ProductID} not found.");
            }

            // Update the existing product with the new values from the command
            existingProduct.ProductName = request.ProductName;
            existingProduct.Price = request.Price;

            // Mark the entity as modified and save changes
            context.Products.Update(existingProduct);
            await context.SaveChangesAsync(cancellationToken);

            // Invalidate the cache for this product
            await InvalidateCache(existingProduct);
        }

        private async Task InvalidateCache(Product product)
        {
            var key = $"product-{product.ProductID}";
            await cache.RemoveAsync(key);
        }
    }
}