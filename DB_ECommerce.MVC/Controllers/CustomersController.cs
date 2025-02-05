using Microsoft.AspNetCore.Mvc;

namespace DB_ECommerce.MVC.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
