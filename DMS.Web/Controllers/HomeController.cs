using AspNetCoreHero.ToastNotification.Abstractions;
using DMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, INotyfService notyf)
        {
            _logger = logger;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
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