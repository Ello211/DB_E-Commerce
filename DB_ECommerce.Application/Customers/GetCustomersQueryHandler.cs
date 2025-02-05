using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Customers;

public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentQuery, List<Customer>>
{
    private readonly DB_ECommerceContext context;

    public GetPaymentsQueryHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task<List<Customer>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var customers = await context.Customers.ToListAsync(cancellationToken);
        return customers;
    }
}