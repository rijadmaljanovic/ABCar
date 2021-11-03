using ABCar.Business;
using ABCar.Business.Helpers;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.Areas.Zaposlenik.Controllers
{
    [Area("Zaposlenik")]
    [ActionFilter(zaposlenik: true)]
    public class AccountController : Controller
    {
        private readonly ZaposlenikOperations zaposlenikOperations;
        private readonly KorisnickiRacunOperations korisnickiRacunOperations;
        private readonly Models.EntityModels.Korisnici.Zaposlenik logiraniZaposlenik;

        public AccountController()
        {
            zaposlenikOperations = new ZaposlenikOperations();
            logiraniZaposlenik = SessionCookieHelper.GetLoggedZaposlenik();
            korisnickiRacunOperations = new KorisnickiRacunOperations();
        }
        public IActionResult PrikaziZaposlenika()
        {

            if (logiraniZaposlenik == null)
                return RedirectToAction("Index", "Home");

            return View(zaposlenikOperations.GetUrediVMById(logiraniZaposlenik.Id));

        }

        public IActionResult UrediZaposlenika()
        {
            if (logiraniZaposlenik == null)
                return RedirectToAction("Index", "Home");

            return View(zaposlenikOperations.GetUrediVMById(logiraniZaposlenik.Id));
        }

        [HttpPost]
        public IActionResult UrediZaposlenika(UrediZaposlenikaVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            zaposlenikOperations.Update(model);

            TempData["Confirmation"] = "Podaci uspjesno spremljeni!";

            return RedirectToAction("Index", "Home");


        }

        public IActionResult UrediPassword()
        {
            if (logiraniZaposlenik == null)
                RedirectToAction("Index", "Home");

            return View(korisnickiRacunOperations.GetUrediVMById(logiraniZaposlenik.KorisnickiRacunId));


        }

        [HttpPost]
        public IActionResult UrediPassword(UrediKorisnickiRacunVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (korisnickiRacunOperations.IsUsernameUsed(model.Username, model.KorisnickiRacunId))
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