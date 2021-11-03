using ABCar.Business;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ActionFilter(admin:true)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}