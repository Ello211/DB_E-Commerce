﻿namespace DB_ECommerce.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public DateOnly? Birthdate { get; set; }

        public DateOnly AccountCreated { get; set; }

        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
