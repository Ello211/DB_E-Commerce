using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Payments;
public class CreatePaymentCommand : IRequest
{
    public string Currency { get; set; }

    public string PaymentMethod { get; set; }

    public string PaymentStatus { get; set; }

    public decimal PaymentAmount { get; set; }

    public decimal OpenPayment { get; set; }

    public int OrderID { get; set; }
}

