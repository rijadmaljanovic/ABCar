using ABCar.Business;
using ABCar.Models.Shared;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.Areas.Login.Controllers
{
    [Area("Login")]
    public class HomeController : Controller
    {
        private readonly LoginOperations loginOperations;
        private readonly KorisnickiRacunOperations korisnickiRacunOperations;

        public HomeController()
        {
            loginOperations = new LoginOperations();
            korisnickiRacunOperations = new KorisnickiRacunOperations();
        }

        public IActionResult Index(int korisnickiRacunId = -1)
        {
            return View(loginOperations.GetVMForLogin(korisnickiRacunId));
        }

        [HttpPost]
        public IActionResult Index(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var korisnickiRacun = loginOperations.LogIn(model);

            if (korisnickiRacun == null)
            {
                ViewBag.Error = "Nije pronadjen korisnicki racun za uneseni username i password!";
                return View(model);
            }

            switch (korisnickiRacun.TipKorisnika)
            {
                case TipKorisnika.Administrator:
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                case TipKorisnika.Zaposlenik:
                    return RedirectToAction("Index", "Home", new { area = "Zaposlenik" });
                case TipKorisnika.Kupac:
                    return RedirectToAction("Index", "Home", new { area = "Kupac" });
            }

            return NotFound();

        }

        public IActionResult Logout(string url)
        {
            loginOperations.LogOut();

            return RedirectToAction("Index", "Home", new { area = "Pocetna" });

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var kupacOperations = new KupacOperations();

            if (korisnickiRacunOperations.IsUsernameUsed(model.Username))
            {
                ViewBag.Error = "Korisnicko ime zauzeto!";
                return View(model);
            }

            var kupac=kupacOperations.Register(model);

            TempData["Confirmation"] = "Korisnik uspjesno registrovan!";

            return RedirectToAction("Index", "Home", new { area = "Login", korisnickiRacunId = kupac.KorisnickiRacunId });


        }


    }
}