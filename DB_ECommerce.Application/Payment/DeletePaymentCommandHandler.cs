using MediatR;

using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Payments;

public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand>
{
    private readonly DB_ECommerceContext context;

    public DeletePaymentCommandHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await context.Payments.FindAsync(request.PaymentID, cancellationToken);
        if (payment != null)
        {
            context.Payments.Remove(payment);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}