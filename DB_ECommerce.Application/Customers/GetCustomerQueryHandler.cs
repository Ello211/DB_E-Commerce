using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;
using DB_ECommerce.Application.Customers;

namespace DB_ECommerce.Application.Customers;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
{
    private readonly DB_ECommerceContext context;

    public GetCustomerQueryHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await context.Customers.FirstOrDefaultAsync(c => c.CustomerID == request.CustomerID, cancellationToken);
        return customer;
    }
}