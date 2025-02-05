using MediatR;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand>
    {
        private readonly ECommerceContext context;

        public DeleteProductCategoryCommandHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await context.ProductCategories
                .FirstOrDefaultAsync(pc => pc.ProductId == request.ProductId && pc.CategoryId == request.CategoryId, cancellationToken);

            if (productCategory == null)
            {
                throw new KeyNotFoundException($"ProductCategory with ProductId {request.ProductId} and CategoryId {request.CategoryId} not found.");
            }

            context.ProductCategories.Remove(productCategory);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
