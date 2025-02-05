using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;
using DB_E_Commerce.E_Commerce.Application.Products;

namespace DB_E_Commerce.Application.Products
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
            var existingProduct = await context.Products.FindAsync(new object[] { request.Id }, cancellationToken);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }

            existingProduct.ProductName = request.ProductName;
            existingProduct.Price = request.Price;
            existingProduct.Products_Categories = request.ProductCategories;

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
