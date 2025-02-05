namespace DB_ECommerce.Models
{
    public class Product_Category
    {
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        public Product Product { get; set; }

        public Category Category { get; set; }

    }
}
