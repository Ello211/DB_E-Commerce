using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Categories
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
                .FirstOrDefaultAsync(c => c.CategoryID == request.CategoryID, cancellationToken);

            if (existingCategories == null)
            {
                throw new KeyNotFoundException($"Category with CategoryID {request.CategoryID} not found.");
            }

            existingCategories.CategoryName = request.CategoryName;

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
