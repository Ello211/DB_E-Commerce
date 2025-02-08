using MediatR;

using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Orders
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly DB_ECommerceContext context;

        public DeleteOrderCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FindAsync(new object[] { request.OrderID }, cancellationToken);
            if (order != null)
            {
                throw new KeyNotFoundException($"Order with OrderID {request.OrderID} not found.");
            }

            context.Orders.Remove(order);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
