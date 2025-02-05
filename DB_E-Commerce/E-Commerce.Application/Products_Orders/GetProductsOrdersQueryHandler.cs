using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DB_E_Commerce.E_Commerce.Application.Product_Orders
{
    public class GetProductsOrdersQueryHandler : IRequestHandler<GetProductsOrdersQuery, List<ProductOrder>>
    {
        private readonly ECommerceContext context;

        public GetProductsOrdersQueryHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<List<ProductOrder>> Handle(GetProductsOrdersQuery request, CancellationToken cancellationToken)
        {
            var productOrders = await context.ProductOrders.ToListAsync(cancellationToken);

            if (productOrders == null || productOrders.Count == 0)
            {
                throw new KeyNotFoundException("No ProductOrders found.");
            }

            return productOrders;
        }
    }
}
