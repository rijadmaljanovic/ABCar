using System;
using ABCar.Business;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ActionFilter(admin: true)]
    public class EvidencijaZaposlenikaController : Controller
    {
        private ZaposlenikOperations zaposlenikOperations { get; set; }

        public EvidencijaZaposlenikaController()
        {
            zaposlenikOperations = new ZaposlenikOperations();
        }

        public IActionResult SviZaposlenici()
        {
            return View(zaposlenikOperations.GetAll());
        }

        public IActionResult DodajNovogZaposlenika()
        {
            return View(new DodajZaposlenikaVM { DatumZaposljenja = DateTime.Today });
        }

        [HttpPost]
        public IActionResult DodajNovogZaposlenika(DodajZaposlenikaVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (new KorisnickiRacunOperations().IsUsernameUsed(model.Username))
            {
                ViewBag.Error = "Korisnicko ime zauzeto!";
                return View(model);
            }

            zaposlenikOperations.Add(model);

            TempData["Confirmation"] = "Novi zaposlenik uspjesno dodan!";

            return RedirectToAction("SviZaposlenici");
        }

        public IActionResult UrediZaposlenika(int zaposlenikId)
        {
            return View(zaposlenikOperations.GetUrediVMById(zaposlenikId));
        }

        [HttpPost]
        public IActionResult UrediZaposlenika(UrediZaposlenikaVM model)
        {
            if (!ModelState.IsValid)
                return View(model);


            zaposlenikOperations.Update(model);

            TempData["Confirmation"] = "Zaposlenik uspjesno uredjen!";

            return RedirectToAction("SviZaposlenici");


        }

        public IActionResult ObrisiZaposlenika(int zaposlenikId)
        {
            zaposlenikOperations.Remove(zaposlenikId);

            TempData["Confirmation"] = "Zaposlenik izbrisan!";

            return RedirectToAction("SviZaposlenici");


        }
    }
}