using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
