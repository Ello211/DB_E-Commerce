using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Customers
{
    public class GetPaymentQuery : IRequest<List<Customer>>
    {
    }
}
