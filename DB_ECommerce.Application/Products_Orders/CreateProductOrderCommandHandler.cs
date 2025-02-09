using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Product_Orders
{
    public class CreateProductOrderCommandHandler : IRequestHandler<CreateProductOrderCommand>
    {
        private readonly DB_ECommerceContext context;

        public CreateProductOrderCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(CreateProductOrderCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.ProductID == request.ProductID, cancellationToken);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ProductID {request.ProductID} not found.");
            }

            var order = await context.Orders.FirstOrDefaultAsync(o => o.OrderID == request.OrderID, cancellationToken);

            if (order == null)
            {
                throw new KeyNotFoundException($"Product with ProductID {request.OrderID} not found.");
            }

            var totalPrice = product.Price * request.Quantity;

            var productOrder = new Product_Order
            {
                Product = product,
                Order = order,
                Quantity = request.Quantity,
                TotalPrice = totalPrice
            };

            context.Add(productOrder);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
