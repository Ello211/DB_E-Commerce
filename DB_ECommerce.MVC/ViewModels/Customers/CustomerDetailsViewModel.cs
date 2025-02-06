namespace DB_ECommerce.MVC.ViewModels.Customers
{
    public class CustomerDetailsViewModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateOnly? Birthday { get; set; }
        public DateOnly AccountCreated { get; set; }
        public string Email {  get; set; }

        public static CustomerDetailsViewModel FromCustomer(DB_ECommerce.Models.Customer customer)
        {
            return new CustomerDetailsViewModel
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Birthday = customer.Birthday,
                AccountCreated = customer.AccountCreated,
                Email = customer.Email
            };

        }

        
    }
}
