using DB_ECommerce.Application.Orders;
using DB_ECommerce.Models;

namespace DB_ECommerce.MVC.ViewModels.Orders
{
    public class OrderUpdateViewModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public int CustomerID { get; set; }
    }
}
