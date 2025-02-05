using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Products
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly ECommerceContext context;

        public GetProductsQueryHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await context.Products.ToListAsync(cancellationToken);
            return products;
        }
    }
}
