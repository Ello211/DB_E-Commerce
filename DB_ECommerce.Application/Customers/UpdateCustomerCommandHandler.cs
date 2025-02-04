using MediatR;

using Microsoft.Build.Framework;
using Microsoft.Extensions.Caching.Distributed;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Customers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdatePaymentCommand>
{
    private readonly DB_ECommerceContext context;
    private readonly IDistributedCache cache;

    public UpdateCustomerCommandHandler(DB_ECommerceContext context, IDistributedCache cache)
    {
        this.context = context;
        this.cache = cache;
    }

    public async Task Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToCustomer();

        context.Update(customer);

        await context.SaveChangesAsync(cancellationToken);

        await this.InvalidateCache(customer);
    }

    private async Task InvalidateCache(Customer customer)
    {
        var key = $"customer-{customer.CustomerID}";
        await this.cache.RemoveAsync(key);
    }
}