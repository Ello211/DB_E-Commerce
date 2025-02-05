using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Payments;

public class GetPaymentsListQueryHandler : IRequestHandler<GetPaymentsListQuery, List<Payment>>
{
    private readonly DB_ECommerceContext context;

    public GetPaymentsListQueryHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task<List<Payment>> Handle(GetPaymentsListQuery request, CancellationToken cancellationToken)
    {
        var payments = await context.Payments
            .Include(payment => payment.Order)
            .ToListAsync(cancellationToken);

        return payments;
    }
}