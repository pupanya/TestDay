using Microsoft.AspNetCore.Mvc;

namespace TestDay.Front.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}