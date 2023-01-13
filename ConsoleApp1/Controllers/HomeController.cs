using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using BookWebApp.Models;
using BookWebApp.Repository;
using BookWebApp.Service;

namespace BookWebApp.Controllers
{
    public class HomeController : Controller
    {
       
        /// <summary>
        /// returns the home page of application
        /// </summary>
        /// <returns></returns>

        public async Task<ViewResult> Index()
        {
            return View();
        }

        /// <summary>
        /// return the about us page for bookwebapp
        /// </summary>
        /// <returns></returns>
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
