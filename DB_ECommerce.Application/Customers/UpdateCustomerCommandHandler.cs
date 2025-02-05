using MediatR;

using DB_ECommerce.Persistence;

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
        var customer = request.ToCustomer();

        context.Add(customer);

        await context.SaveChangesAsync(cancellationToken);
    }
}