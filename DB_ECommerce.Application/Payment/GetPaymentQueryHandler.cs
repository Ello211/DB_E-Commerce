using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Payments;

public class GetPaymentQueryHandler : IRequestHandler<GetShipmentQuery, Payment>
{
    private readonly DB_ECommerceContext context;

    public GetPaymentQueryHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task<Payment> Handle(GetShipmentQuery request, CancellationToken cancellationToken)
    {
        var payment = await context.Payments
            .Include(payment => payment.Order)

            .FirstOrDefaultAsync(payment => payment.PaymentID == request.PaymentID, cancellationToken);

        return payment;
    }
}