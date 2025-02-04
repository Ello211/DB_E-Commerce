using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Customers;

public class GetCustomerQuery : IRequest<Customer>
{
    public int CustomerID { get; set; }
}