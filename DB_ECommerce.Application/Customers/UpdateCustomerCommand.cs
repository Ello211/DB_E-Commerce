using MediatR;

using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Customers;
public class UpdatePaymentCommand : IRequest
{
    public int CustomerID { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Address { get; set; }

    public DateOnly? Birthday { get; set; }

    public DateOnly AccountCreated { get; set; }

    public string Email { get; set; }

    public Customer ToCustomer()
    {
        var customer = new Customer
        {
            CustomerID = this.CustomerID, 
            Firstname = this.Firstname,
            Lastname = this.Lastname,
            Address = this.Address,
            Birthday = this.Birthday,
            AccountCreated = this.AccountCreated,
            Email = this.Email
        };

        return customer;
    }
}

