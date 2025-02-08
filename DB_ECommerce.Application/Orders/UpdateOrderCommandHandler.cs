using MediatR;
using DB_ECommerce.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DB_ECommerce.Application.Orders
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly DB_ECommerceContext context;

        public UpdateOrderCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var existingOrder = await context.Orders
            .Include(order => order.Customer)
            .FirstOrDefaultAsync(mark => mark.OrderID == request.OrderID, cancellationToken);

            if (existingOrder == null)
            {
                throw new NullReferenceException("Order not found");
            }

            var customer = await context.Customers.FirstOrDefaultAsync(c => c.CustomerID == request.CustomerID, cancellationToken);
            if (customer == null)
            {
                throw new NullReferenceException("Customer not found");
            }

            existingOrder.OrderDate = request.OrderDate;
            existingOrder.TotalPrice = request.TotalPrice;
            existingOrder.Customer = customer;

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}