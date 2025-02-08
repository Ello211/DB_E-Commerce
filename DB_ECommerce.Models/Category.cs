namespace DB_ECommerce.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}