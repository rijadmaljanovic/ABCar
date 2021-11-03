using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCar.Business;
using ABCar.Business.Helpers;
using ABCar.Models.EntityModels;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.ViewComponents
{
    public class AddVoziloToFavourite : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int voziloId)
        {
            // provjera je li user postoji u sesiji
            var kupac = SessionCookieHelper.GetLoggedKupac();

            var model = new VoziloFavoritiVM();

            if (kupac == null)
                model.KupacId = null;
            else
            {

                model.KupacId = kupac.Id;
                model.VoziloId = voziloId;
                model.VecUFavoritima=new VoziloOperations().IsVoziloVecUFavoritima(voziloId,kupac.Id);
            }

            return View(model);
        }

    }

}
