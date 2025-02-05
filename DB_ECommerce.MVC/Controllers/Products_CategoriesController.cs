using Microsoft.AspNetCore.Mvc;

namespace DB_ECommerce.MVC.Controllers
{
    public class Products_CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
