using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, ProductCategory>
    {
        private readonly ECommerceContext context;

        public GetProductCategoryQueryHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<ProductCategory> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var productCategory = await context.ProductCategories
                .FirstOrDefaultAsync(pc => pc.ProductId == request.ProductId && pc.CategoryId == request.CategoryId, cancellationToken);

            if (productCategory == null)
            {
                throw new KeyNotFoundException($"ProductCategory with ProductId {request.ProductId} and CategoryId {request.CategoryId} not found.");
            }

            return productCategory;
        }
    }
}
