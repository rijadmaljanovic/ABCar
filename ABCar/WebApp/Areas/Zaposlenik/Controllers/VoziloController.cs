using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCar.Business;
using ABCar.Business.Helpers;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels;
using ABCar.Models.EntityModels.Vozila;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Zaposlenik.Controllers
{
    [Area("Zaposlenik")]
    [ActionFilter(zaposlenik:true)]
    public class VoziloController : Controller
    {
        private readonly NabavkaOperations nabavkaOperations;
        private readonly ProdajaOperations prodajaOperations;
        private readonly SlikeOperations slikeOperations;
        private readonly VoziloOperations voziloOperations;
        private readonly ABCar.Models.EntityModels.Korisnici.Zaposlenik logiraniZaposlenik;

        public VoziloController()
        {
            logiraniZaposlenik = SessionCookieHelper.GetLoggedZaposlenik();
            nabavkaOperations=new NabavkaOperations();
            voziloOperations=new VoziloOperations();
            slikeOperations=new SlikeOperations();
            prodajaOperations=new ProdajaOperations();
        }


        public IActionResult UrediVozilo(string sifra)
        {
            TempData["sifra"] = sifra;

            return View("UrediVozilo",sifra);
        }

        public IActionResult UrediPodatkeOVozilu(int voziloId)
        {
            return View("UrediPodatkeOVozilu",voziloOperations.GetUrediVoziloVMById(voziloId,TempData["sifra"]?.ToString()));
        }

        public IActionResult NovaNabavka()
        {
            return View(new UrediVoziloVM
            {
                RefVrijednosti = voziloOperations.GetRefVrijednostiZZaVozilo(),
                Vozilo = new Vozilo()
            });
        }

        [HttpPost]
        public IActionResult NovaNabavka(UrediVoziloVM model)
        {
            if (!ModelState.IsValid)
            {
                model.RefVrijednosti = voziloOperations.GetRefVrijednostiZZaVozilo();
                return View(model);
            }

            nabavkaOperations.AddNabavka(model, logiraniZaposlenik.Id);

            TempData["Confirmation"] = "Podaci uspjesno spremljeni!";

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public IActionResult UrediPodatkeOVozilu(UrediVoziloVM model)
        {
            if (!ModelState.IsValid)
            {
                model = voziloOperations.GetUrediVoziloVMById(model.Vozilo.Id,null);
                return View(model);
            }

            nabavkaOperations.UrediNabavku(model);

            TempData["Confirmation"] = "Podaci uspjesno spremljeni!";

            return RedirectToAction("UrediVozilo", new { sifra = model.sifraVozilaZaPretragu });
        }

        public IActionResult GetVozilabySifra(string sifra)
        {
            TempData["sifra"] = sifra;

            return PartialView("VozilaBySifra",voziloOperations.GetVozilaBySifra(sifra));
        }

        public IActionResult UrediSlike(int voziloId)
        {
            return View(new UrediSlikeVM{
                VoziloId = voziloId,
                SlikeVozila = slikeOperations.GetSlikeByVoziloId(voziloId),
            });
        }

        public IActionResult IzbrisiSliku(int slikaId, int voziloId)
        {
            slikeOperations.RemoveSlika(slikaId, voziloId);

            TempData["Confirmation"] = "Slika uspjesno izbrisana!";

            return new EmptyResult();

        }

        [HttpPost]
        public IActionResult DodajNoveSlike(UrediSlikeVM model)
        {
            if (model.PhotoFiles != null)
            {
                slikeOperations.AddSlike(model.PhotoFiles, model.VoziloId);
                TempData["Confirmation"] = "Slike uspjesno spremljene!";
            }

            return RedirectToAction("UrediSlike",new{voziloId=model.VoziloId});
        }

        public IActionResult IzbrisiSveSlike(int voziloId)
        {
            slikeOperations.IzbrisiSveSlike(voziloId);

            TempData["Confirmation"] = "Slike uspjesno izbrisane!";

            return new EmptyResult();

        }

        public IActionResult SetAkcijuZaVozilo(float? akcijaPosto, int voziloId,int sifra)
        {
            voziloOperations.SetVoziloNaAkciju(voziloId,akcijaPosto);
            return RedirectToAction("GetVozilabySifra",new{sifra=sifra});

        }

        public IActionResult ProdajVozilo(int voziloId,float iznos,int sifra)
        {
            prodajaOperations.AddProdaja(voziloId, iznos, logiraniZaposlenik.Id);

            TempData["Confirmation"] = "Prodaja uspjenso evidentirana!";

            return RedirectToAction("GetVozilabySifra", new { sifra = sifra });

        }


    }
}