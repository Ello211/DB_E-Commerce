using System.ComponentModel.DataAnnotations;
using DB_ECommerce.Application.Customers;

namespace DB_ECommerce.MVC.ViewModels.Customers
{
    public class CustomerCreateViewModel
    {
        [Required]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }
        [Display(Name = "Lastname")]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Birthday")]
        public DateOnly? Birthday { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }


        public CreateCustomerCommand ToCreateCustomerCommand()
        {
            return new CreateCustomerCommand
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Address = this.Address,
                Birthday = this.Birthday,
                Email = this.Email,

            };

        }
    }
}
