using HangFire.Web.BackgroundJobs;
using HangFire.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HangFire.Web.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            //Üye Kayıt İşlemi
            //Yeni üye olan userId'sini al
            FireAndForgetJob.EmailSendToUserJob("1234", "Sitemize Hoş Geldiniz");
            return View();
        }
        [HttpGet]
        public IActionResult PictureSave()
        {
            BackgroundJobs.RecurringJob.ReportingJob();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PictureSave(IFormFile picture)
        {
            string newFileName= String.Empty;
            if(picture != null && picture.Length>0) 
            {
                newFileName= Guid.NewGuid().ToString()+ Path.GetExtension(picture.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures" , newFileName);
                using(var stream = new FileStream(path,FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }
                string jobID = BackgroundJobs.DelayedJob.AddWatermarkJob(newFileName,"www.mysite.com");
                BackgroundJobs.ContinuationsJob.WriteWatermarkStatusJob(jobID, newFileName);
            }
            return View();
        }
    }
}