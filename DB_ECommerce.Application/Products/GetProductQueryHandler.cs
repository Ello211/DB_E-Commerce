using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Products
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly DB_ECommerceContext context;
        private readonly IDistributedCache cache;

        private TimeSpan threeMonths = new(0, 3, 0, 0, 0, 0);

        public GetProductQueryHandler(DB_ECommerceContext context, IDistributedCache cache)
        {
            this.context = context;
            this.cache = cache;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await GetProductFromCache(request);
            if (product != null)
            {
                return product;
            }

            product = await GetProductFromDatabase(request, cancellationToken);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }

            await SetProductToCache(product);

            return product;
        }


        private async Task SetProductToCache(Product product)
        {
            var key = $"product-{product.ProductID}";

            var productAsSerializedJson = JsonSerializer.Serialize(product);

            await cache.SetStringAsync(key, productAsSerializedJson, options: new DistributedCacheEntryOptions { SlidingExpiration = threeMonths });
        }

        private async Task<Product> GetProductFromCache(GetProductQuery request)
        {
            var key = $"product-{request.Id}";

            var productAsSerializedJson = await cache.GetStringAsync(key);
            if (productAsSerializedJson == null)
            {
                return null;
            }

            var product = JsonSerializer.Deserialize<Product>(productAsSerializedJson);
            return product;
        }

        private async Task<Product> GetProductFromDatabase(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.ProductID == request.Id, cancellationToken);
            return product;
        }
    }
}
