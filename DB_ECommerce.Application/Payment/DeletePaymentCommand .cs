using MediatR;

namespace DB_ECommerce.Application.Payments;

public class DeletePaymentCommand : IRequest
{
    public int PaymentID { get; set; }
}