using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCar.Business;
using ABCar.Business.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.ViewComponents
{
    public class PonudaViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ponuda = new PonudaOperations().GetPretragaViewModel();
            return View(ponuda);

        }

    }
}
