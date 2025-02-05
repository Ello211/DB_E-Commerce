using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, Product_Category>
    {
        private readonly DB_ECommerceContext context;

        public GetProductCategoryQueryHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<Product_Category> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var productCategory = await context.Products_Categories
                .FirstOrDefaultAsync(pc => pc.ProductID == request.ProductId && pc.CategoryID == request.CategoryId, cancellationToken);

            if (productCategory == null)
            {
                throw new KeyNotFoundException($"ProductCategory with ProductId {request.ProductId} and CategoryId {request.CategoryId} not found.");
            }

            return productCategory;
        }
    }
}
