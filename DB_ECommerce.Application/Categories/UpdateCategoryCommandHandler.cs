using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Categories
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly DB_ECommerceContext context;

        public UpdateCategoryCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingCategories = await context.Categories
                .Include(c => c.ProductsCategories)
                .FirstOrDefaultAsync(c => c.CategoryID == request.Id, cancellationToken);

            if (existingCategories == null)
            {
                throw new KeyNotFoundException($"Category with ID {request.Id} not found.");
            }

            existingCategories.CategoryName = request.CategoryName;

            foreach (var productCategory in request.ProductCategories)
            {
                var existingProductCategory = existingCategories.ProductsCategories
                    .FirstOrDefault(pc => pc.ProductID == productCategory.ProductID);

                if (existingProductCategory == null)
                {
                    existingCategories.ProductsCategories.Add(productCategory);
                }
                else if (!request.ProductCategories.Contains(existingProductCategory))
                {
                    existingCategories.ProductsCategories.Remove(existingProductCategory);
                }
            }

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
