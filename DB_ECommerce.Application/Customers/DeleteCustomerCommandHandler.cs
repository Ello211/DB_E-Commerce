using MediatR;

using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Customers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly DB_ECommerceContext context;

    public DeleteCustomerCommandHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await context.Customers.FindAsync(request.CustomerID, cancellationToken);
        if (customer != null)
        {
            context.Customers.Remove(customer);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}