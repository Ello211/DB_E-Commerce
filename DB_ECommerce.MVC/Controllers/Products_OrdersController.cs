using Microsoft.AspNetCore.Mvc;

namespace DB_ECommerce.MVC.Controllers
{
    public class Products_OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
