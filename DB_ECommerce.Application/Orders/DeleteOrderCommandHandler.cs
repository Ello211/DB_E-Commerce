using MediatR;
using DB_E_Commerce.E_Commerce.Application.Orderss;
using DB_ECommerce.Persistence;

namespace DB_E_Commerce.E_Commerce.Application.Orderss
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
            var order = await context.Orders.FindAsync(new object[] { request.Id }, cancellationToken);
            if (order != null)
            {
                throw new KeyNotFoundException($"Order with ID {request.Id} not found.");
            }

            context.Orders.Remove(order);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
