using MediatR;
using DB_ECommerce.Models;
using DB_ECommerce.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB_E_Commerce.E_Commerce.Application.Products_Categories
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand>
    {
        private readonly DB_ECommerceContext context;

        public CreateProductCategoryCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = new Product_Category
            {
                ProductID = request.ProductId,
                CategoryID = request.CategoryId
            };

            context.Products_Categories.Add(productCategory);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
