using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABCar.Models.Shared
{
    public class VoziloRefVrijednosti
    {
        public List<SelectListItem> Marke { get; set; }
        public List<SelectListItem> Modeli { get; set; }
        public List<SelectListItem> VrstePogona { get; set; }
        public List<SelectListItem> BrojVrata { get; set; }
        public List<SelectListItem> VrsteMjenjaca { get; set; }
        public List<SelectListItem> Boje { get; set; }
        public List<SelectListItem> VrsteKaroserije { get; set; }
        public List<SelectListItem> VrsteMotora { get; set; }
        public List<SelectListItem> VrsteSvjetla { get; set; }
        public List<SelectListItem> EmisioniStandardi { get; set; }
        public List<SelectListItem> BrojSjedecihMjesta { get; set; }
        public List<SelectListItem> VelicinaFelgi { get; set; }
        public List<SelectListItem> GodinaProizvodnje { get; set; }
        public List<SelectListItem> BrojBrzina { get; set; }
    }
}
