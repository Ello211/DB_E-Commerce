using System.ComponentModel.DataAnnotations;
using DB_ECommerce.Application.Customers;

namespace DB_ECommerce.MVC.ViewModels.Customers
{
    public class CustomerUpdateViewModel
    {
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Birthday")]
        public DateOnly? Birthday { get; set; }
        public DateOnly AccountCreated { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public static CustomerUpdateViewModel FromCustomer(DB_ECommerce.Models.Customer customer)
        {
            return new CustomerUpdateViewModel
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address, 
                Birthday = customer.Birthday,
                AccountCreated = customer.AccountCreated,
                Email = customer.Email,

            };
        }

        public UpdateCustomerCommand ToUpdateCustomerCommand()
        {
            return new UpdateCustomerCommand
            {
                CustomerID = this.CustomerID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Address = this.Address,
                Birthday = this.Birthday,
                AccountCreated = this.AccountCreated,
                Email = this.Email,
            };

        }
    }
}
