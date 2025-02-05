using Microsoft.AspNetCore.Mvc;

namespace DB_ECommerce.MVC.Controllers
{
    public class ShipmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
