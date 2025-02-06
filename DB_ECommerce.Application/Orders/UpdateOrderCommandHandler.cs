using MediatR;
using DB_E_Commerce.E_Commerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Orderss
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly ECommerceContext context;

        public UpdateOrderCommandHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var existingOrder = await context.Orders.FindAsync(new object[] { request.Id }, cancellationToken);

            if (existingOrder == null)
            {
                throw new KeyNotFoundException($"Order with ID {request.Id} not found.");
            }

            existingOrder.CustomerId = request.CustomerId;
            existingOrder.OrderDate = request.OrderDate;
            existingOrder.TotalPrice = request.TotalPrice;
            existingOrder.Products_Orders = request.ProductsOrders;

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
