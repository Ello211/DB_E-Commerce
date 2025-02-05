using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class GetProductsCategoriesQueryHandler : IRequestHandler<GetProductsCategoriesQuery, List<ProductCategory>>
    {
        private readonly ECommerceContext context;

        public GetProductsCategoriesQueryHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<List<ProductCategory>> Handle(GetProductsCategoriesQuery request, CancellationToken cancellationToken)
        {
            var productsCategories = await context.ProductsCategories.ToListAsync(cancellationToken);

            if (productsCategories == null || productsCategories.Count == 0)
            {
                throw new KeyNotFoundException("No ProductCategories found.");
            }

            return productsCategories;
        }
    }
}
