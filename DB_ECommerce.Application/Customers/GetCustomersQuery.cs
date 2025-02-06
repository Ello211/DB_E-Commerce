using MediatR;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Customers
{
    public class GetCustomersQuery : IRequest<List<Customer>>
    {
    }
}
