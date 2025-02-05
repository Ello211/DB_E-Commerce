using MediatR;

using Microsoft.EntityFrameworkCore;

using DB_ECommerce.Models;
using DB_ECommerce.Persistence;

namespace DB_ECommerce.Application.Payments;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand>
{
    private readonly DB_ECommerceContext context;

    public CreatePaymentCommandHandler(DB_ECommerceContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FirstOrDefaultAsync(c => c.OrderID == request.OrderID, cancellationToken);
        if (order == null)
        {
            throw new NullReferenceException("Order not found");
        }

        var payment = new Payment
        {
            Currency = request.Currency,
            PaymentMethod = request.PaymentMethod,
            PaymentStatus = request.PaymentStatus,
            PaymentAmount = request.PaymentAmount,
            OpenPayment = request.OpenPayment,
            Order = order
        };

        context.Add(order);
        await context.SaveChangesAsync(cancellationToken);
    }
}