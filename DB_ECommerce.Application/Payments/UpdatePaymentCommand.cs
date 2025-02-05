using MediatR;

namespace DB_ECommerce.Application.Payments;
public class UpdatePaymentCommand : IRequest
{
    public int PaymentID { get; set; }

    public string Currency { get; set; }

    public string PaymentMethod { get; set; }

    public string PaymentStatus { get; set; }

    public decimal PaymentAmount { get; set; }

    public decimal OpenPayment { get; set; }

    public int OrderID { get; set; }
}

