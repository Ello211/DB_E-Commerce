
using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;


namespace DB_ECommerce.Application.Categories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly DB_ECommerceContext context;

        public GetCategoriesQueryHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync(cancellationToken);
            return categories;
        }
    }
}
