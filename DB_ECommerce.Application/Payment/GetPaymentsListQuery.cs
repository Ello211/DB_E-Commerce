using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Payments;

public class GetPaymentsListQuery : IRequest<List<Payment>>
{
}
