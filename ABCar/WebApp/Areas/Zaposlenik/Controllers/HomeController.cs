using ABCar.Business;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.Areas.Zaposlenik.Controllers
{
    [Area("Zaposlenik")]
    [ActionFilter(zaposlenik:true)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}