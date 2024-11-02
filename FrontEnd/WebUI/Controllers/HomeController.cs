using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var token=User.Claims.FirstOrDefault(x=>x.Type=="accessToken").Value;
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var userId = userIdClaim.Value;
            //burada token ýn içinden ýd deðerini aldým.
            if (token != null)
            {
                
                return View();
            }

            //token ý taþýyabiliyor muyum diye denedim oluyor.
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
