using MediatR;

namespace DB_ECommerce.Application.Customers;
public class UpdateCustomerCommand : IRequest
{
    public int CustomerID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public DateOnly? Birthday { get; set; }

    public DateOnly AccountCreated { get; set; }

    public string Email { get; set; }

}

