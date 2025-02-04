using MediatR;

using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Customers;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand>
{
    private readonly DB_ECommerceContext context;

    public CreatePaymentCommandHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToCustomer();

        context.Add(customer);

        await context.SaveChangesAsync(cancellationToken);
    }
}