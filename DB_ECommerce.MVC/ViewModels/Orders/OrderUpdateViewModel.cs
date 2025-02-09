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


        public static OrderUpdateViewModel FromOrder(DB_ECommerce.Models.Order order)
        {  
            return new OrderUpdateViewModel 
            { 
                OrderID = order.OrderID, 
                OrderDate = order.OrderDate, 
                TotalPrice = order.TotalPrice,
                Customer = order.Customer
            }; 
        }

        public UpdateOrderCommand ToUpdateOrderCommand()
        {
            return new UpdateOrderCommand
            {
                OrderID = this.OrderID,
                OrderDate = this.OrderDate,
                TotalPrice = this.TotalPrice,
                CustomerID = this.CustomerID

            };
        }
    }
}
