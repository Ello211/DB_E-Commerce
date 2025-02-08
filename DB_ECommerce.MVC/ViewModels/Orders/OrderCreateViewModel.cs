using System.ComponentModel.DataAnnotations;
using DB_E_Commerce.E_Commerce.Application.Orderss;
using DB_ECommerce.Models;

namespace DB_ECommerce.MVC.ViewModels.Orders
{
    public class OrderCreateViewModel
    {
        [Required]
        [Display(Name = "Customer")]
        public Customer Customer { get; set; }
        [Required]
        [Display(Name = "Payment")]
        public Payment Payment { get; set; }
    }
}
