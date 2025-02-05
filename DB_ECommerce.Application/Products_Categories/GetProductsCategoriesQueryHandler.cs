using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class GetProductsCategoriesQueryHandler : IRequestHandler<GetProductsCategoriesQuery, List<Product_Category>>
    {
        private readonly DB_ECommerceContext context;

        public GetProductsCategoriesQueryHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Product_Category>> Handle(GetProductsCategoriesQuery request, CancellationToken cancellationToken)
        {
            var productsCategories = await context.Products_Categories.ToListAsync(cancellationToken);

            if (productsCategories == null || productsCategories.Count == 0)
            {
                throw new KeyNotFoundException("No ProductCategories found.");
            }

            return productsCategories;
        }
    }
}
