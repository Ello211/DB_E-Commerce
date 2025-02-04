using MediatR;

using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Customers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly DB_ECommerceContext context;

    public CreateCustomerCommandHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToCustomer();

        context.Add(customer);

        await context.SaveChangesAsync(cancellationToken);
    }
}