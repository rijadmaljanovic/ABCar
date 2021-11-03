using System;
using System.Linq;
using ABCar.Business;
using ABCar.Business.Helpers;
using ABCar.DAL;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.EntityModels.Vozila;
using ABCar.Models.Shared;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.Areas.Pocetna.Controllers
{
    [Area("Pocetna")]
    public class HomeController : Controller
    {
        public MojDBContext db { get; }

        public HomeController(MojDBContext con)
        {
            db = con;
        }

        public IActionResult Index()
        {
            if (SessionCookieHelper.GetUserFromCookie() != null)
            {
                SessionCookieHelper.RefreshSessionAndCookieFromCookie();
                return RedirectToAction("Index", "Home", new { area = "Kupac" });
            }

            var any = db.KorisnickiRacun.Any();

            if (!any)
            {
                //DBInitializer.Seed(db);
                KorisnickiRacunOperations.CreateAdminAccount();
            }

            return View("Index",false);
        }


    }
}