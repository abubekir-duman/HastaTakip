using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;
using System.Text;

namespace MVC.Controllers
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

        //Home/About
        //IActionResult /base'in implemente ettiði interfaca
        //ActionResult  /base
        //ViewResult abstract sýnýf olan ActioResult'tan miras alýr

        public ViewResult About()
        {
            //return new ViewResult();
            return View();
        }

        public ActionResult Contact()
        {
            return View("Ýletisim");
        }

        public ContentResult Tarih()
        {
            //return new ContentResult()
            //{
            //    Content = "Bugünün Tarihi: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"),
            //    ContentType = "text/plain",
            //    StatusCode = 200
            //};

            return Content("Bugünün Tarihi: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"),"text/plain",Encoding.UTF8);
        }

        public IActionResult Baslik()
        {
            return Content("<p style=\"color:blue;\">Hasta Takip</p>", "text/html");
        }

        public RedirectResult Microsof()
        {
            //return new RedirectResult("https://microsoft.com");

            return Redirect("https://microsoft.com");
        }
    }
}
