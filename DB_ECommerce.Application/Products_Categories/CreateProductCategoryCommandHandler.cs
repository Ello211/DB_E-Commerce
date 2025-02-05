using MediatR;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand>
    {
        private readonly ECommerceContext context;

        public CreateProductCategoryCommandHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = new ProductCategory
            {
                ProductId = request.ProductId,
                CategoryId = request.CategoryId
            };

            context.ProductCategories.Add(productCategory);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
