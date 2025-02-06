using Microsoft.AspNetCore.Mvc;

namespace DB_ECommerce.MVC.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
