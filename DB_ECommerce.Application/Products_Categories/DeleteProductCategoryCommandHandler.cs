using MediatR;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand>
    {
        private readonly DB_ECommerceContext context;

        public DeleteProductCategoryCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await context.Products_Categories
                .FirstOrDefaultAsync(pc => pc.ProductID == request.ProductId && pc.CategoryID == request.CategoryId, cancellationToken);

            if (productCategory == null)
            {
                throw new KeyNotFoundException($"ProductCategory with ProductId {request.ProductId} and CategoryId {request.CategoryId} not found.");
            }

            context.Products_Categories.Remove(productCategory);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
