using System;
using System.Collections.Generic;
using System.Text;
using ABCar.Models.EntityModels.Vozila;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABCar.Models.ViewModels
{
    public class PretragaVM
    {
        public int? MarkeId { get; set; }
        public int? ModelId { get; set; }
        public int? GodinaProizvodnjeOd { get; set; }
        public int? GodinaProizvodnjeDo { get; set; }
        public int? CijenaOd { get; set; }
        public int? CijenaDo { get; set; }
        public int? VrstaMjenjacaId { get; set; }
        public int? VrstaMotoraId { get; set; }
        public VrstaSortiranja? VrstaSortiranja { get; set; }
        public bool? Novo { get; set; }


        public List<SelectListItem> Marke { get; set; }
        public List<SelectListItem> Modeli { get; set; }
        public List<SelectListItem> GodinaProizvodnjeItems { get; set; }
        public List<SelectListItem> CijeneItems { get; set; }
        public List<SelectListItem> VrstaMjenjaca { get; set; }
        public List<SelectListItem> VrstaMotora { get; set; }
        public List<MarkaVozila> Proizvodjaci { get; set; }

        public List<SelectListItem> Sortiranja { get; set; }

    }

    public class VoziloZaPonudu
    {
        public int Id { get; set; }

        public string Cijena { get; set; }

        public string Marka { get; set; }

        public string Model { get; set; }

        public string PredjeniKM { get; set; }

        public string GodinaProizvodnje { get; set; }

        public string ImgPath { get; set; }

        public bool Akcija { get; set; }

        public bool Novo { get; set; }


    }

    public enum VrstaSortiranja
    {
        MarkaSilazno,MarkaUzlazno,CijenaSilazno,CijenaUzlazno,GodisteUzlazno, GodisteSilazno,PredjenikmSilazno, PredjenikmUzlazno
    }
}
