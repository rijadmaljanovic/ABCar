using ABCar.Business;
using ABCar.Business.Helpers;
using ABCar.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.Areas.Kupac.Controllers
{
    [Area("Kupac")]
    [ActionFilter(kupac: true)]
    public class HomeController : Controller
    {
        private readonly KupacOperations kupacOperations;

        public HomeController()
        {
            kupacOperations = new KupacOperations();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DodajVoziloUFavorite(int voziloId, int kupacId)
        {
            kupacOperations.AddVoziloToFavourites(voziloId, kupacId);

            return ViewComponent("AddVoziloToFavourite", new { voziloId = voziloId });
        }

        public IActionResult PrikaziFavorite()
        {
            var model = kupacOperations.GetFavorite();

            return View(model);
        }

        public IActionResult UkloniFavorita(int voziloId)
        {
            kupacOperations.UkloniFavorita(voziloId);

            return RedirectToAction("PrikaziFavorite");

        }

        public IActionResult PrikaziNotifikacije()
        {
            var kupacId = SessionCookieHelper.GetLoggedKupac().Id;

            var notifikacijeRepository = new NotificationRepository();
            notifikacijeRepository.SetNotifikacijeVidjene(kupacId);
            var model = notifikacijeRepository.GetNotificationsForKupac(kupacId);

            return View(model);
        }

    }
}