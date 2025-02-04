using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Payments;

public class GetPaymentQueryQueryHandler : IRequestHandler<GetPaymentQuery, Payment>
{
    private readonly DB_ECommerceContext context;

    public GetPaymentQueryQueryHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task<Payment> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var payment = await context.Payments
            .Include(payment => payment.Order)

            .FirstOrDefaultAsync(payment => payment.PaymentID == request.PaymentID, cancellationToken);

        return payment;
    }
}