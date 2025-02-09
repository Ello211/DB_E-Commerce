using System.ComponentModel.DataAnnotations;
using DB_ECommerce.Application.Orders;

namespace DB_ECommerce.MVC.ViewModels.Orders
{
    public class OrderCreateViewModel
    {
        [Required]
        [Display(Name = "Order Date)")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

       

        public CreateOrderCommand ToCreateOrderComman()
        {
            return new CreateOrderCommand
            {
                OrderDate = this.OrderDate,
                TotalPrice = this.TotalPrice,
                CustomerID = this.CustomerID,
                
            };
        }
    }
}
