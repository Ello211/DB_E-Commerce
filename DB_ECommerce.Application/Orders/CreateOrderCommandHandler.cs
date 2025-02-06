using MediatR;
using DB_ECommerce.Persistence;
using DB_ECommerce.Models;
using Microsoft.EntityFrameworkCore;



namespace DB_ECommerce.Application.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly DB_ECommerceContext context;

        public CreateOrderCommandHandler(DB_ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(c => c.CustomerID == request.CustomerID, cancellationToken);
            if (customer == null)
            {
                throw new NullReferenceException("Customer not found");
            }

            var order = new Order
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                Customer = customer
            };

            context.Add(order);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}