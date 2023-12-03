using ErrorHandlingUdemy.Filter;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingUdemy.Controllers
{
   //[CustomHandleExceptionFilterAttribute(ErrorPage = "Hata2")]

    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Veri tabanında hata meydana geldi");
            return View();
        }
        
    }
}
