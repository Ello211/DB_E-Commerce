using MediatR;
using Microsoft.Extensions.Caching.Distributed;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;


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
            var existingProduct = await context.Products.FindAsync(new object[] { request.ProductID }, cancellationToken);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ProductID {request.ProductID} not found.");
            }

            context.Update(existingProduct);

            await context.SaveChangesAsync(cancellationToken);

            await this.InvalidateCache(existingProduct);
        }

        private async Task InvalidateCache(Product product)
        {
            var key = $"product-{product.ProductID}";
            await this.cache.RemoveAsync(key);
        }
    }
}
