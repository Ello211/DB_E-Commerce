namespace DB_E_Commerce.Models
{
    public class CustomerInfo
    {
        public int CustomerID { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public DateOnly? Birthdate { get; set; }

        public DateOnly AccountCreated { get; set; }
        
        public string Email { get; set; }

    }
}
