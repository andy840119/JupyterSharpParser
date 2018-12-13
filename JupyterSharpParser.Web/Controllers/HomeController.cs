using System.Diagnostics;
using JupyterSharpParser.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace JupyterSharpParser.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //befire design homepage, just direct to Jupyter converter page
            return RedirectToAction("Index", "Jupyter");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
