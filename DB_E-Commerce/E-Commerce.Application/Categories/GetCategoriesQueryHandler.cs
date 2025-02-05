
using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;


namespace DB_E_Commerce.E_Commerce.Application.Categories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly ECommerceContext context;

        public GetCategoriesQueryHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories
                .Include(c => c.ProductsCategories)
                    .ThenInclude(pc => pc.Product)
                .ToListAsync(cancellationToken);
            return categories;
        }
    }
}
