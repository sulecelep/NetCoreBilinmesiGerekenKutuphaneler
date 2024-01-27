using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UdemyEnvironment.Models;

namespace UdemyEnvironment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //www.tenohub.com
        //www.alfa.teknohub.com
        public IActionResult Index()
        {
            //throw new Exception("Hata var");
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
