using MediatR;
using Microsoft.EntityFrameworkCore;
using DB_E_Commerce.Persistence;

namespace DB_E_Commerce.Application.Orders
{
    public class GetOrderReferencesQueryHandler : IRequestHandler<GetOrderReferencesQuery, OrderReferences>
    {
        private readonly ECommerceContext context;

        public GetOrderReferencesQueryHandler(ECommerceContext context)
        {
            this.context = context;
        }

        public async Task<OrderReferences> Handle(GetOrderReferencesQuery request, CancellationToken cancellationToken)
        {
            var allCustomers = await context.Customers.ToListAsync(cancellationToken);
            var allShipments = await context.Shipments.ToListAsync(cancellationToken);
            var allPayments = await context.Payments.ToListAsync(cancellationToken);

            return new OrderReferences
            {
                Customers = allCustomers,
                Shipments = allShipments,
                Payments = allPayments
            };
        }
    }
}
