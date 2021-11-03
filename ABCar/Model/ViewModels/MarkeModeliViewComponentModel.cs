
using System;
using System.Collections.Generic;
using System.Text;
using ABCar.Models.EntityModels.Vozila;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABCar.Models.ViewModels
{
    public class MarkeModeliViewComponentModel
    {
        public List<SelectListItem> Marke { get; set; }
        public int? ModelId { get; set; }
    }
}
