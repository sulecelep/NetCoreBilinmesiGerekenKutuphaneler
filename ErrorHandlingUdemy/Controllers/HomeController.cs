using ErrorHandlingUdemy.Filter;
using ErrorHandlingUdemy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ErrorHandlingUdemy.Controllers
{
    //[CustomHandleExceptionFilterAttribute(ErrorPage = "Hata1")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[CustomHandleExceptionFilterAttribute(ErrorPage ="Hata1")]
        public IActionResult Index()
        {
            //throw new Exception("Veri tabanına bağlanırken bir hata meydana geldi.");
            int value1 = 5;
            int value2 = 0;
            int result = value1 / value2;
            return View();
        }
        //[CustomHandleExceptionFilterAttribute(ErrorPage = "Hata2")]
        public IActionResult Privacy()
        {
            throw new FileNotFoundException();
            //return View();
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.path = exception.Path;
            ViewBag.message = exception.Error.Message;
            return View();
        }
        
        public IActionResult Hata1()
        {
            return View();
        }
        public IActionResult Hata2()
        {
            return View();
        }
    }
}
