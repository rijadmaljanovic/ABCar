using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels.Vozila;
using ABCar.Models.Shared;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Remotion.Linq.Clauses;

namespace ABCar.Business
{
    public class VoziloOperations
    {
        private readonly VoziloRepository voziloRepository;
        private readonly NabavkaRepository nabavkaRepository;

        public VoziloOperations()
        {
            voziloRepository = new VoziloRepository();
            nabavkaRepository=new NabavkaRepository();
        }

        public void Add(Vozilo x)
        {
            voziloRepository.Add(x);
        }

        public VoziloRefVrijednosti GetRefVrijednostiZZaVozilo()
        {
            var refVrijednosti= new VoziloRefVrijednosti
            {
                Boje = voziloRepository.GetBoja()
                    .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList(),
                BrojBrzina = voziloRepository.GetBrojBrzina()
                    .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList(),
                BrojVrata = voziloRepository.GetBrojVrata()
                    .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList(),
                EmisioniStandardi = voziloRepository.GetEmisioniStandard()
                    .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList(),
                VrsteKaroserije = voziloRepository.GetTipoviVozila()
                    .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList(),
                VrsteMjenjaca = voziloRepository.GetVrstaMjenjaca()
                    .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList(),
                VrsteMotora = voziloRepository.GetVrstaMotora()
                    .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList(),
                VrstePogona = voziloRepository.GetVrstaPogona()
                    .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList(),
                VrsteSvjetla = voziloRepository.GetVrstaSvjetla()
                    .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList(),
                Marke = voziloRepository.GetMarkaVozila()
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList(),
                Modeli = voziloRepository.GetModelVozila()
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList(),
                BrojSjedecihMjesta = new List<SelectListItem>
                {
                    new SelectListItem{Text = "2",Value = "2"},
                    new SelectListItem{Text = "3",Value = "3"},
                    new SelectListItem{Text = "4",Value = "4"},
                    new SelectListItem{Text = "5",Value = "5"},
                    new SelectListItem{Text = "6",Value = "6"},
                    new SelectListItem{Text = "7",Value = "7"},
                    new SelectListItem{Text = "8",Value = "8"},
                    new SelectListItem{Text = "9",Value = "9"}
                },
                VelicinaFelgi = new List<SelectListItem>
                {
                    new SelectListItem{Text="13",Value = "13"},
                    new SelectListItem{Text="14",Value = "14"},
                    new SelectListItem{Text="15",Value = "15"},
                    new SelectListItem{Text="16",Value = "16"},
                    new SelectListItem{Text="17",Value = "17"},
                    new SelectListItem{Text="18",Value = "18"},
                    new SelectListItem{Text="19",Value = "19"},
                    new SelectListItem{Text="20",Value = "20"},
                    new SelectListItem{Text="21",Value = "21"},
                    new SelectListItem{Text="22",Value = "22"},
                    new SelectListItem{Text="23",Value = "23"},
                    new SelectListItem{Text="24",Value = "24"}
                }
            };

            refVrijednosti.GodinaProizvodnje=new List<SelectListItem>();
            for(int i = 1960; i < 2019; i++)
                refVrijednosti.GodinaProizvodnje.Add(new SelectListItem{Text = i.ToString(),Value = i.ToString()});


            return refVrijednosti;

        }

        public List<SelectListItem> GetMarkeAll(int? selectedMarkaId=null)
        {
            return voziloRepository.GetMarkaVozila()
                .Select(m => new SelectListItem {Value = m.Id.ToString(), Text = m.Naziv, Selected = m.Id==selectedMarkaId}).ToList();
        }

        public List<SelectListItem> GetModeliByMarkaId(int markaId, int? modelId)
        {
            return voziloRepository.GetModelVozilaByMarkaId(markaId)
                .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Naziv , Selected = m.Id==modelId}).ToList();
        }

        public string GetMarkaLogoPath(int markaId)
        {
            return voziloRepository.GetMarkaLogoPath(markaId);
        }

        public UrediVoziloVM GetUrediVoziloVMById(int voziloId, string sifra)
        {
            var model = new UrediVoziloVM
            {
                Vozilo = voziloRepository.GetVoziloMarkaModelById(voziloId),
                RefVrijednosti = GetRefVrijednostiZZaVozilo(),
                NabavnaCijena =  nabavkaRepository.GetNabavkaByVoziloId(voziloId)?.Cijena,
                sifraVozilaZaPretragu = sifra
            };

            return model;
        }

        public List<Vozilo> GetVozilaBySifra(string sifra)
        {
            return voziloRepository.GetVozilaBySifra(Int32.Parse(sifra));
        }

        public void Update(Vozilo vozilo)
        {
            voziloRepository.Update(vozilo);
        }

        public void SetVoziloNaAkciju(int voziloId, float? akcijaPosto)
        {
            voziloRepository.SetAkcijuVozilu(voziloId, akcijaPosto);
        }

        public bool IsVoziloVecUFavoritima(int voziloId, int kupacId)
        {
            return voziloRepository.IsVoziloVecUFavoritima(voziloId, kupacId);
        }
    }
}
