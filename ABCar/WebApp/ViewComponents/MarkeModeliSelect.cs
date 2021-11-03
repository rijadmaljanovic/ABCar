using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCar.Business;
using ABCar.Business.Helpers;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.ViewComponents
{
    public class MarkeModeliSelect : ViewComponent
    {
        private readonly VoziloOperations voziloOperations;

        public MarkeModeliSelect()
        {
            voziloOperations = new VoziloOperations();
        }

        public async Task<IViewComponentResult> InvokeAsync(int? markaId=null, int? modelId=null)
        {
            return View(new MarkeModeliViewComponentModel
            {
                Marke = voziloOperations.GetMarkeAll(markaId),
                ModelId = modelId
            });

        }

    }


}