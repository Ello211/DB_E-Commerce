using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Categories
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Category>
    {
        private readonly DB_ECommerceContext context;

        public GetCategoryQueryHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.CategoryID == request.CategoryID, cancellationToken);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with CategoryID {request.CategoryID} not found.");
            }

            return category;
        }
    }
}
