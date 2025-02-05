using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;

namespace DB_E_Commerce.Application.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly ECommerceContext context;
        private readonly IDistributedCache cache;

        public UpdateProductCommandHandler(ECommerceContext context, IDistributedCache cache)
        {
            this.context = context;
            this.cache = cache;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await context.Products.FindAsync(new object[] { request.Id }, cancellationToken);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }

            existingProduct.ProductName = request.ProductName;
            existingProduct.Price = request.Price;
            existingProduct.ProductCategories = request.ProductCategories;

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
