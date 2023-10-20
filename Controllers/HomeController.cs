using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Verzamelwoede_Dezegaatechtnietstuk.Data;
using Verzamelwoede_Dezegaatechtnietstuk.Models;

namespace Verzamelwoede_Dezegaatechtnietstuk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Item()
        {
            return View();
        }

        public IActionResult Filter()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        public IActionResult HiddenArea()
        {
            return View();
        }

        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Geheim()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult _Tinder() {
            return View();
        }



            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}