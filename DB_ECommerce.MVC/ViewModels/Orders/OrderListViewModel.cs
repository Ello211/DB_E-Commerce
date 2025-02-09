using DB_ECommerce.Models;

namespace DB_ECommerce.MVC.ViewModels.Orders
{
    public class OrderListViewModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }

        public static OrderListViewModel FromOrder(DB_ECommerce.Models.Order order) 
        {
            return new OrderListViewModel
            {
                OrderID = order.OrderID,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Customer = order.Customer,
                Payment = order.Payment,
            };
        }
    }
}
