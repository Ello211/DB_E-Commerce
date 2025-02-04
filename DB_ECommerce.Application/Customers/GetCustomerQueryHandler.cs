using System.Text.Json;
using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Customers;

public class GetPaymentQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
{
    private readonly DB_ECommerceContext context;
    private readonly IDistributedCache cache;

    private TimeSpan threeMonths = new(0, 3, 0, 0, 0, 0);

    public GetPaymentQueryHandler(DB_ECommerceContext context, IDistributedCache cache)
    {
        this.context = context;
        this.cache = cache;
    }

    public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await GetCustomerFromCache(request);
        if (customer != null)
        {
            return customer;
        }

        customer = await GetCustomerFromDatabase(request, cancellationToken);
        await SetCustomerToCache(customer);

        return customer;
    }

    private async Task SetCustomerToCache(Customer customer)
    {
        var key = $"customer-{customer.CustomerID}";

        var customerAsSerializedJson = JsonSerializer.Serialize(customer);

        await cache.SetStringAsync(key, customerAsSerializedJson, options: new DistributedCacheEntryOptions { SlidingExpiration = threeMonths });
    }

    private async Task<Customer> GetCustomerFromCache(GetCustomerQuery request)
    {
        var key = $"customer-{request.CustomerID}";

        var customerAsSerializedJson = await cache.GetStringAsync(key);
        if (customerAsSerializedJson == null)
        {
            return null;
        }

        var customer = JsonSerializer.Deserialize<Customer>(customerAsSerializedJson);
        return customer;
    }

    private async Task<Customer> GetCustomerFromDatabase(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await context.Customers.FirstOrDefaultAsync(c => c.CustomerID == request.CustomerID, cancellationToken);
        return customer;
    }
}