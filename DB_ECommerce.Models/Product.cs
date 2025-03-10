﻿namespace DB_ECommerce.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public ICollection<Product_Order> Products_Orders { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}
