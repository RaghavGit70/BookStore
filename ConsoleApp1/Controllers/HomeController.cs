using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
