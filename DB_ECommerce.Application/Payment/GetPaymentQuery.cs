using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Payments;

public class GetPaymentQuery : IRequest<Payment>
{
    public int PaymentID { get; set; }
}