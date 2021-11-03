using ABCar.Business;
using ABCar.Business.Helpers;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ABCar.WebApp.Areas.Kupac.Controllers
{
    [Area("Kupac")]
    [ActionFilter(kupac: true)]
    public class AccountController : Controller
    {
        private readonly KupacOperations kupacOperations;
        private readonly KorisnickiRacunOperations korisnickiRacunOperations;
        private readonly Models.EntityModels.Korisnici.Kupac logiraniKupac;

        public AccountController()
        {
            kupacOperations = new KupacOperations();
            logiraniKupac = SessionCookieHelper.GetLoggedKupac();
            korisnickiRacunOperations = new KorisnickiRacunOperations();
        }

        public IActionResult PrikaziKupca()
        {
            if (logiraniKupac == null)
                return RedirectToAction("Index", "Home");

            return View(kupacOperations.GetUrediVMById(logiraniKupac.Id));
        }

        public IActionResult UrediKupca()
        {
            if (logiraniKupac == null)
                return RedirectToAction("Index", "Home");

            return View(kupacOperations.GetUrediVMById(logiraniKupac.Id));
        }

        [HttpPost]
        public IActionResult UrediKupca(UrediKupcaVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            kupacOperations.Update(model);

            TempData["Confirmation"] = "Podaci uspjesno spremljeni!";

            return RedirectToAction("Index", "Home");


        }

        public IActionResult UrediPassword()
        {
            if (logiraniKupac == null)
                RedirectToAction("Index", "Home");

            return View(korisnickiRacunOperations.GetUrediVMById(logiraniKupac.KorisnickiRacunId));


        }

        [HttpPost]
        public IActionResult UrediPassword(UrediKorisnickiRacunVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (korisnickiRacunOperations.IsUsernameUsed(model.Username,model.KorisnickiRacunId))
            {
                ViewBag.Error = "Korisnicko ime je zauzeto!";
                return View(model);
            }

            var updated = korisnickiRacunOperations.UpdateIfOldPasswordMatchAndUpdateSession(model);

            if (!updated)
            {
                ViewBag.Error = "Stara lozinka nije tacna!";
                return View(model);
            }
            else
            {
                TempData["Confirmation"] = "Podaci uspjesno spremljeni!";
                return RedirectToAction("Index", "Home");
            }
        }

    }
}