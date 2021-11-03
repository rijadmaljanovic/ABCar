using System;
using System.Collections.Generic;
using System.Text;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels.Vozila;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABCar.Business
{
    public class PonudaOperations
    {
        private PonudaRepository ponudaRepository { get; set; }
        private VoziloRepository voziloRepository { get; set; }

        public PonudaOperations()
        {
            ponudaRepository = new PonudaRepository();
            voziloRepository=new VoziloRepository();
        }

        public PretragaVM GetPretragaViewModel()
        {
            var model= new PretragaVM
            {
                Marke = ponudaRepository.GetMarke(),
                Modeli = new List<SelectListItem> {new SelectListItem {Value = null, Text = "svi modeli",Selected = true}},
                CijeneItems = GetCijeneItems(),
                GodinaProizvodnjeItems = GetGodineItems(),
                VrstaMjenjaca = ponudaRepository.GetVrsteMjenjaca(),
                VrstaMotora = ponudaRepository.GetVrsteMotora(),
                Proizvodjaci = ponudaRepository.GetProizvodjaciSLogom(),
                Sortiranja = getSortiranjaItems()
            };

            model.Marke.Insert(0, new SelectListItem { Text = "sve marke", Value = null });
            model.VrstaMjenjaca.Insert(0, new SelectListItem { Text = "svi", Value = null });
            model.VrstaMotora.Insert(0, new SelectListItem { Text = "svi", Value = null });
            model.CijeneItems.Insert(0, new SelectListItem { Text = "sve", Value = null });
            model.GodinaProizvodnjeItems.Insert(0, new SelectListItem { Text = "sve", Value = null });

            return model;

        }

        private List<SelectListItem> getSortiranjaItems()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Value = null, Text = "Sortiraj"},
                new SelectListItem {Value = VrstaSortiranja.MarkaUzlazno.ToString(), Text = "Marka- A-Z"},
                new SelectListItem {Value = VrstaSortiranja.MarkaSilazno.ToString(), Text = "Marka- Z-A"},
                new SelectListItem
                    {Value = VrstaSortiranja.CijenaSilazno.ToString(), Text = "Cijena- veca prema manjoj"},
                new SelectListItem
                    {Value = VrstaSortiranja.CijenaUzlazno.ToString(), Text = "Cijena- manja prema vecoj"},
                new SelectListItem {Value = VrstaSortiranja.GodisteUzlazno.ToString(), Text = "Godina- starije prvo"},
                new SelectListItem {Value = VrstaSortiranja.GodisteSilazno.ToString(), Text = "Godina- novije prvo"},
                new SelectListItem
                    {Value = VrstaSortiranja.PredjenikmSilazno.ToString(), Text = "Kilometri- veci prema manjim"},
                new SelectListItem
                    {Value = VrstaSortiranja.PredjenikmUzlazno.ToString(), Text = "Kilometri- manji prema vecima"}
            };

        }

        private List<SelectListItem> GetGodineItems()
        {
            var list = new List<SelectListItem>();
            for (int i = 1970; i < 2020; i++)
            {
                list.Add(new SelectListItem {Text = i.ToString(), Value = i.ToString()});
            }

            return list;
        }

        private List<SelectListItem> GetCijeneItems()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Text = "5 000", Value = "5000"},
                new SelectListItem {Text = "10 000", Value = "10000"},
                new SelectListItem {Text = "15 000", Value = "15000"},
                new SelectListItem {Text = "20 000", Value = "20000"},
                new SelectListItem {Text = "25 000", Value = "25000"},
                new SelectListItem {Text = "30 000", Value = "30000"},
                new SelectListItem {Text = "35 000", Value = "35000"},
                new SelectListItem {Text = "50 000", Value = "50000"},
                new SelectListItem {Text = "75 000", Value = "75000"},
                new SelectListItem {Text = "100 000", Value = "100000"},
                new SelectListItem {Text = "150 000", Value = "150000"},
                new SelectListItem {Text = "200 000", Value = "200000"}
            };
        }

        public List<VoziloZaPonudu> GetPonudaVozilaByParameter(PretragaVM model, int scrollNum=0)
        {
            return ponudaRepository.GetVozilaZaPonudu(model, scrollNum);
        }

        public List<SelectListItem> GetModelByMarkaId(int? markaId)
        {
            if (markaId == null)
                return new List<SelectListItem> { new SelectListItem{Text = "svi", Value = null,Selected = true}};
            else
            {
                var list = ponudaRepository.GetModeli((int)markaId);
                list.Insert(0, new SelectListItem { Text = "svi", Value = null, Selected = true });

                return list;
            }
        }

        public VoziloDetalji GetVoziloDetalji(int id)
        {
           return  ponudaRepository.GetVoziloDetalji(id);
        }

        public List<Vozilo> GetVozilaZaPonudu(string ids)
        {
            var nizId = ids.Split(",");

            var list = new List<Vozilo>();

            foreach (var item in nizId)
            {
                list.Add(voziloRepository.GetVoziloZaUporediti(int.Parse(item)));
            }

            return list;
        }
    }
}
