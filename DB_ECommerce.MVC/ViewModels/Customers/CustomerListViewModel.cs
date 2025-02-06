namespace DB_ECommerce.MVC.ViewModels.Customers
{
    public class CustomerListViewModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateOnly? Birthday { get; set; }
        public DateOnly? AccountCreated { get; set; }
        public string Email { get; set; }


        public static CustomerListViewModel FromCustomer(DB_ECommerce.Models.Customer customer)
        {
            return new CustomerListViewModel
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
    }
}
