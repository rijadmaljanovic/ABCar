using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ABCar.Models;
using ABCar.Models.EntityModels.Vozila;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static ABCar.DAL.DBInitializer;

namespace ABCar.DAL.Repositories
{
    public class PonudaRepository
    {
        private MojDBContext db { get; set; }

        public PonudaRepository()
        {
            db = GetDBInstance();
        }


        public List<SelectListItem> GetMarke()
        {
            return db.MarkaVozila.Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList();
        }

        public List<SelectListItem> GetModeli(int markaId)
        {
            var modeli = db.ModelVozila.Where(x => x.MarkaId == markaId)
                .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList();

            foreach (var item in modeli)
            {
                item.Text += " (" + db.Vozilo.Count(v => v.ModelId == Int32.Parse(item.Value)) + ")";
            }

            return modeli;
        }

        public List<SelectListItem> GetVrsteMjenjaca()
        {
            return db.VrstaMjenjaca.Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList();

        }

        public List<SelectListItem> GetVrsteMotora()
        {
            return db.VrstaMotora.Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Naziv}).ToList();

        }

        public List<VoziloZaPonudu> GetVozilaZaPonudu(int scrollNumber)
        {
            var list = db.Vozilo.Include(v => v.Model)
                .ThenInclude(m => m.Marka)
                .Include(x => x.VrstaMjenjaca)
                .Include(x => x.VrstaMotora)
                //.Take(20)
                .Select(x => new VoziloZaPonudu
                {
                    Id = x.Id,
                    Cijena = ((decimal) x.Cijena).ToString("N1"),
                    GodinaProizvodnje = x.GodinaProizvodnje.ToString(),
                    Marka = x.Model.Marka.Naziv,
                    Model = x.Model.Naziv,
                    PredjeniKM = x.PredjeniKilometri.ToString(),
                    Akcija = x.Akcija != null,
                    Novo = x.Novo
                })
                .ToList();

            foreach (var item in list)
            {
                item.ImgPath = db.SlikeVozila.FirstOrDefault(x => x.VoziloId == item.Id)?.ImgPath ?? null;
            }

            return list;

        }

        public PonudaVM GetVozilaZaPonudu(PretragaVM model, int scrollNumber)
        {
            var vozila = (IQueryable<Vozilo>) db.Vozilo.Include(v => v.Model)
                .ThenInclude(m => m.Marka)
                .Include(x => x.VrstaMjenjaca)
                .Include(x => x.VrstaMotora);

            if (model != null)
                vozila = vozila.Where(v => (model.MarkeId == null || v.Model.MarkaId == model.MarkeId) &&
                                           (model.ModelId == null || v.ModelId == model.ModelId) &&
                                           (model.VrstaMjenjacaId == null ||
                                            v.VrstaMjenjacaId == model.VrstaMjenjacaId) &&
                                           (model.VrstaMotoraId == null || v.VrstaMotoraId == model.VrstaMotoraId) &&
                                           (model.GodinaProizvodnjeOd == null ||
                                            v.GodinaProizvodnje >= model.GodinaProizvodnjeOd) &&
                                           (model.GodinaProizvodnjeDo == null ||
                                            v.GodinaProizvodnje <= model.GodinaProizvodnjeDo) &&
                                           (model.CijenaOd == null || v.Cijena >= model.CijenaOd) &&
                                           (model.CijenaDo == null || v.Cijena <= model.CijenaDo) &&
                                           (model.Novo == null || v.Novo == model.Novo) &&
                                           (v.Prodano==false)
                );


            switch (model.VrstaSortiranja)
            {
                case VrstaSortiranja.CijenaSilazno:
                {
                    vozila = vozila.OrderByDescending(v => v.Cijena);
                    break;
                }
                case VrstaSortiranja.CijenaUzlazno:
                {
                    vozila = vozila.OrderBy(v => v.Cijena);
                    break;
                }
                case VrstaSortiranja.PredjenikmSilazno:
                {
                    vozila = vozila.OrderByDescending(v => v.PredjeniKilometri);
                    break;
                }
                case VrstaSortiranja.PredjenikmUzlazno:
                {
                    vozila = vozila.OrderBy(v => v.PredjeniKilometri);
                    break;
                }
                case VrstaSortiranja.GodisteSilazno:
                {
                    vozila = vozila.OrderByDescending(v => v.GodinaProizvodnje);
                    break;
                }
                case VrstaSortiranja.GodisteUzlazno:
                {
                    vozila = vozila.OrderBy(v => v.GodinaProizvodnje);
                    break;
                }
                case VrstaSortiranja.MarkaSilazno:
                {
                    vozila = vozila.OrderByDescending(v => v.Model.Marka.Naziv);
                    break;
                }
                case VrstaSortiranja.MarkaUzlazno:
                {
                    vozila = vozila.OrderBy(v => v.Model.Marka.Naziv);
                    break;
                }
                case null:
                {
                    vozila.OrderBy(v => v.Id);
                    break;
                }
            }

            var brojVozilaIzBaze = vozila.Count();
            var brojUzetihDoSadIzBaze = (scrollNumber+1) * 20;

            var imaLiJosVozila = brojVozilaIzBaze > brojUzetihDoSadIzBaze;

            vozila = vozila.Skip(scrollNumber*20).Take(20);


            var list = vozila.Select(x => new VoziloZaPonudu
                {
                    Id = x.Id,
                    Cijena = ((decimal) x.Cijena).ToString("N1"),
                    GodinaProizvodnje = x.GodinaProizvodnje.ToString(),
                    Marka = x.Model.Marka.Naziv,
                    Model = x.Model.Naziv,
                    PredjeniKM = x.PredjeniKilometri.ToString(),
                    Akcija = (x.Akcija !=null && x.Akcija>0),
                    Novo = x.Novo,
                })
                .ToList();


            foreach (var item in list)
            {
                item.ImgPath = db.SlikeVozila.FirstOrDefault(x => x.VoziloId == item.Id)?.ImgPath ?? null;
            }


            var model3=new PonudaVM
            {
                ListaVozila=list,
                PrikazanaSvaVozila=!imaLiJosVozila
            };

            return model3;
        }

        public List<MarkaVozila> GetProizvodjaciSLogom()
        {
            return db.MarkaVozila.Where(m => m.LogoImagePath != null).ToList();
        }

        public VoziloDetalji GetVoziloDetalji(int id)
        {
            var model = new VoziloDetalji
            {
                Vozilo = db.Vozilo.Include(v => v.Model).ThenInclude(m => m.Marka)
                    .Include(v => v.EmisioniStandard)
                    .Include(v => v.VrstaSvjetla)
                    .Include(v => v.Boja)
                    .Include(v => v.BrojVrata)
                    .Include(v => v.VrstaPogona)
                    .Include(v => v.TipVozila)
                    .Include(v => v.VrstaMotora)
                    .Include(v => v.BrojBrzina)
                    .Include(v => v.VrstaMjenjaca)
                    .FirstOrDefault(v => v.Id == id),
                Slike = db.SlikeVozila.Where(sv => sv.VoziloId == id).Select(sv => sv.ImgPath).ToList()
            };
            return model;
        }

    }
}
