using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using hirokutest.Models;

namespace hirokutest.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Managment system
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
            // i am tired , now i realized my father and mother dedicate their life for us
            // i am tired , now i dont 
            // i am tired
            // i am tired

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
