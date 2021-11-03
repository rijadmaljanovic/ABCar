using ABCar.Business;
using Microsoft.AspNetCore.Mvc;

namespace ABCar.WebApp.Areas.Shared.Controllers
{
    [Area("Shared")]
    public class AjaxController : Controller
    {
        private readonly VoziloOperations voziloOperations;

        public AjaxController()
        {
            voziloOperations = new VoziloOperations();
        }

        public IActionResult GetModeli(int markaId, int?modelId=null)
        {
            var model = markaId != -1?voziloOperations.GetModeliByMarkaId(markaId,modelId):null;
            return PartialView("Modeli",model);
        }

        public IActionResult GetLogo(int markaId)
        {
            var model = markaId != -1 ? voziloOperations.GetMarkaLogoPath(markaId) : null;
            return PartialView("Logo",model);
        }
    }
}