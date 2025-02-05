using MediatR;
using DB_E_Commerce.E_Commerce.Persistence;
using DB_E_Commerce.E_Commerce.Application.Orderss;


namespace DB_E_Commerce.E_Commerce.Application.Orderss
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly ECommerceContext context;

        public CreateOrderCommandHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.ToOrder();

            context.Orders.Add(order);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
