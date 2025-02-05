﻿using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Categories
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Category>
    {
        private readonly ECommerceContext context;

        public GetCategoryQueryHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await context.Categories
                .Include(c => c.ProductsCategories)
                    .ThenInclude(pc => pc.Product)
                .FirstOrDefaultAsync(c => c.CategoryID == request.Id, cancellationToken);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {request.Id} not found.");
            }

            return category;
        }
    }
}
