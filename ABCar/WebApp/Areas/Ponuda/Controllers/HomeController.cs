using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCar.Business;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Ponuda.Controllers
{
    [Area("Ponuda")]
    public class HomeController : Controller
    {
        public PonudaOperations PonudaOperations { get; set; }

        public HomeController()
        {
            PonudaOperations=new PonudaOperations();
        }

        [HttpPost]
        public IActionResult GetVozilaByParameters(PretragaVM model, int scrollNum)
        {
            var ponuda = PonudaOperations.GetPonudaVozilaByParameter(model,scrollNum);

            return PartialView("PonudaPartialView", ponuda);
        }

        public IActionResult GetVozilaByProizvodjacId(int markaId)
        {
            var ponuda = PonudaOperations.GetPonudaVozilaByParameter(new PretragaVM{MarkeId = markaId});

            return PartialView("PonudaPartialView", ponuda);
        }


        public IActionResult GetModelByMarkaId(int? markaId)
        {
            var model =  PonudaOperations.GetModelByMarkaId(markaId);

            return PartialView(model);
        }

        public IActionResult GetVoziloDetalji(int id)
        {

            var model = PonudaOperations.GetVoziloDetalji(id);
            return PartialView("VoziloDetalji", model);

        }

        public IActionResult UporediVozila(string ids)
        {
            var model = PonudaOperations.GetVozilaZaPonudu(ids);

            return PartialView("Uporedi", model);


        }

    }
}