using ABCar.Models.EntityModels.Vozila;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using static ABCar.DAL.DBInitializer;

namespace ABCar.DAL.Repositories
{
    public class VoziloRepository
    {
        private MojDBContext db { get; set; }

        public VoziloRepository()
        {
            db = GetDBInstance();
        }

        public void Add(Vozilo x)
        {
            db.Vozilo.Add(x);
            db.SaveChanges();
        }

        public Vozilo GetVoziloMarkaModelById(int id)
        {
            return db.Vozilo.Include(x => x.Model).ThenInclude(m => m.Marka).FirstOrDefault(x => x.Id == id);
        }

        public Vozilo GetVoziloById(int id)
        {
            return db.Vozilo.FirstOrDefault(x => x.Id == id);
        }



        // GETTERS FOR SelectList

        public List<TipVozila> GetTipoviVozila()
        {
            return db.TipVozila.ToList();
        }
        public List<BrojBrzina> GetBrojBrzina()
        {
            return db.BrojBrzina.ToList();
        }
        public List<VrstaSvjetla> GetVrstaSvjetla()
        {
            return db.VrstaSvjetla.ToList();
        }
        public List<MarkaVozila> GetMarkaVozila()
        {
            return db.MarkaVozila.ToList();
        }
        public List<ModelVozila> GetModelVozila()
        {
            return db.ModelVozila.ToList();
        }
        public List<ModelVozila> GetModelVozilaByMarkaId(int markaId)
        {
            return db.ModelVozila.Where(m => m.MarkaId == markaId).ToList();
        }
        public List<EmisioniStandard> GetEmisioniStandard()
        {
            return db.EmisioniStandard.ToList();
        }
        public List<VrstaMjenjaca> GetVrstaMjenjaca()
        {
            return db.VrstaMjenjaca.ToList();
        }
        public List<VrstaMotora> GetVrstaMotora()
        {
            return db.VrstaMotora.ToList();
        }
        public List<BrojVrata> GetBrojVrata()
        {
            return db.BrojVrata.ToList();
        }
        public List<Boja> GetBoja()
        {
            return db.Boja.ToList();
        }
        public List<VrstaPogona> GetVrstaPogona()
        {
            return db.VrstaPogona.ToList();
        }

        public string GetMarkaLogoPath(int markaId)
        {
            return db.MarkaVozila.FirstOrDefault(m => m.Id == markaId)?.LogoImagePath;
        }

        public List<Vozilo> GetVozilaBySifra(int sifra)
        {
            return db.Vozilo.Include(x => x.Model)
                .ThenInclude(m => m.Marka)
                .Where(v => v.Prodano == false && v.SifraVozila.ToString().Contains(sifra.ToString()))
                .ToList();
        }

        public void Update(Vozilo vozilo)
        {
            //provjera zbog notifikacije
            var staroVozilo = db.Vozilo.Include(v => v.Model).ThenInclude(m => m.Marka).AsNoTracking().FirstOrDefault(v => v.Id == vozilo.Id);
            if (staroVozilo.Cijena > vozilo.Cijena)
                new NotificationRepository().setNotificationsForVozilo(vozilo.Id, staroVozilo.Model.Marka.Naziv + " " + staroVozilo.Model.Naziv + " smanjena cijena sa [" + staroVozilo.Cijena + " KM] na [" + vozilo.Cijena + " KM]");

            db.Vozilo.Update(vozilo);
            db.SaveChanges();
        }

        public int GetBrojacZaSlikeAndIncrementIt(int voziloId)
        {
            var vozilo = db.Vozilo.FirstOrDefault(x => x.Id == voziloId);

            if (vozilo == null)
                return -1;

            vozilo.brojacZaSlike++;
            var brojac = vozilo.brojacZaSlike;

            db.SaveChanges();

            return brojac;
        }

        public void SetAkcijuVozilu(int voziloId, float? akcijaPosto)
        {
            var vozilo = db.Vozilo.Include(v => v.Model).ThenInclude(m => m.Marka).FirstOrDefault(v => v.Id == voziloId);
            new NotificationRepository().setNotificationsForVozilo(vozilo.Id, vozilo.Model.Marka.Naziv + " " + vozilo.Model.Naziv + (akcijaPosto!=null?(" trenutno na akciji [" + akcijaPosto + " %]"):(" vise nije na akciji!")));


            db.Vozilo.FirstOrDefault(x => x.Id == voziloId).Akcija = akcijaPosto;
            db.SaveChanges();
        }

        public void SetVoziloProdano(int voziloId)
        {
            var vozilo = db.Vozilo.FirstOrDefault(v => v.Id == voziloId);
            vozilo.Prodano = true;
            db.SaveChanges();
        }

        public bool IsVoziloVecUFavoritima(int voziloId, int kupacId)
        {
            return db.VoziloFavorit.Any(vf => vf.VoziloId == voziloId && vf.KupacId == kupacId);
        }

        public Vozilo GetVoziloZaUporediti(int parse)
        {
            return db.Vozilo.Include(v => v.Model).ThenInclude(m => m.Marka)
                .Include(v => v.VrstaMotora)
                .Include(v => v.VrstaMjenjaca)
                .Include(v => v.TipVozila)
                .Include(v => v.Boja)
                .Include(v => v.BrojVrata)
                .Include(v => v.VrstaPogona)
                .Include(v => v.EmisioniStandard)
                .Include(v => v.VrstaSvjetla)
                .Include(v => v.BrojBrzina)
                .FirstOrDefault(v => v.Id == parse);
        }
    }
}
