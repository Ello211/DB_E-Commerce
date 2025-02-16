using MediatR;

using DB_ECommerce.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DB_ECommerce.Application.Customers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly DB_ECommerceContext context;

    public UpdateCustomerCommandHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var existingCustomer = await context.Customers
            .FirstOrDefaultAsync(customer => customer.CustomerID == request.CustomerID, cancellationToken);

        if (existingCustomer == null)
        {
            throw new NullReferenceException("Customer not found");
        }

        existingCustomer.FirstName = request.FirstName;
        existingCustomer.LastName = request.LastName;
        existingCustomer.Address = request.Address;
        existingCustomer.Birthday = request.Birthday;
        existingCustomer.AccountCreated = request.AccountCreated;
        existingCustomer.Email = request.Email;

        await context.SaveChangesAsync(cancellationToken);
    }
}