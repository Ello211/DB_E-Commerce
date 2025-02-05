﻿using MediatR;
using DB_E_Commerce.E_Commerce.Models;
using DB_E_Commerce.E_Commerce.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB_E_Commerce.E_Commerce.Application.Product_Orders
{
    public class CreateProductOrderCommandHandler : IRequestHandler<CreateProductOrderCommand>
    {
        private readonly ECommerceContext context;

        public CreateProductOrderCommandHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(CreateProductOrderCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.ProductID == request.ProductId, cancellationToken);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.ProductId} not found.");
            }

            var totalPrice = product.Price * request.Quantity;

            var productOrder = new ProductOrder
            {
                ProductId = request.ProductId,
                OrderId = request.OrderId,
                Quantity = request.Quantity,
                TotalPrice = totalPrice
            };

            context.ProductOrders.Add(productOrder);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
