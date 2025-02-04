using MediatR;

using Microsoft.Extensions.Caching.Distributed;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Customers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly DB_ECommerceContext context;
    private readonly IDistributedCache cache;

    public DeleteCustomerCommandHandler(DB_ECommerceContext context, IDistributedCache cache)
    {
        this.context = context;
        this.cache = cache;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await context.Customers.FindAsync(request.CustomerID, cancellationToken);
        if (customer != null)
        {
            context.Customers.Remove(customer);
        }

        await context.SaveChangesAsync(cancellationToken);

        await this.InvalidateCache(customer);
    }

    private async Task InvalidateCache(Customer customer)
    {
        var key = $"customer-{customer.CustomerID}";
        await this.cache.RemoveAsync(key);
    }
}