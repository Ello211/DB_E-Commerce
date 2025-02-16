using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Product_Orders
{
    public class UpdateProductOrderCommandHandler : IRequestHandler<UpdateProductOrderCommand>
    {
        private readonly DB_ECommerceContext context;

        public UpdateProductOrderCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateProductOrderCommand request, CancellationToken cancellationToken)
        {
            if (request.ProductOrderID <= 0)
            {
                throw new ArgumentException("ProductOrderID must be greater than 0.");
            }


            var productOrder = await context.Products_Orders
                .Include(po => po.Product) 
                .FirstOrDefaultAsync(po => po.ProductOrderID == request.ProductOrderID, cancellationToken);

            if (productOrder == null)
            {
                throw new KeyNotFoundException($"Product_Order with ProductOrderID {request.ProductOrderID} not found.");
            }

            productOrder.Quantity = request.Quantity;

            productOrder.TotalPrice = productOrder.Quantity * productOrder.Product.Price;

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
