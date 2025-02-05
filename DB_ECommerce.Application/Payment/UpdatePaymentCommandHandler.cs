using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Persistence;
using DB_ECommerce.Application.Customers;

namespace DB_ECommerce.Application.Payments;

public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand>
{
    private readonly DB_ECommerceContext context;

    public UpdatePaymentCommandHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        var existingPayment = await context.Payments
            .Include(payment => payment.Order)
            .FirstOrDefaultAsync(payment => payment.PaymentID == request.PaymentID, cancellationToken);

        if (existingPayment == null)
        {
            throw new NullReferenceException("Payment not found");
        }

        var order = await context.Orders.FirstOrDefaultAsync(o => o.OrderID == request.OrderID, cancellationToken);
        if (order == null)
        {
            throw new NullReferenceException("Order not found");
        }

        existingPayment.Currency = request.Currency;
        existingPayment.PaymentMethod = request.PaymentMethod;
        existingPayment.PaymentStatus = request.PaymentStatus;
        existingPayment.PaymentAmount = request.PaymentAmount;
        existingPayment.OpenPayment = request.OpenPayment;
        existingPayment.Order = order;


        await context.SaveChangesAsync(cancellationToken);
    }
}