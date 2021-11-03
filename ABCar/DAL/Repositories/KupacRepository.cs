using ABCar.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using static ABCar.DAL.DBInitializer;
using VoziloFavorit = ABCar.Models.EntityModels.VoziloFavorit;


namespace ABCar.DAL.Repositories
{
    public class KupacRepository
    {
        private MojDBContext db { get; set; }

        public KupacRepository()
        {
            db = GetDBInstance();
        }

        public void Add(Kupac x)
        {
            db.Kupac.Add(x);
            db.SaveChanges();

        }

        public void Remove(Kupac x)
        {
            db.Kupac.Remove(x);
            db.SaveChanges();

        }

        public void Update(Kupac x)
        {
            db.Kupac.Update(x);
            db.SaveChanges();

        }

        public Kupac GetById(int id)
        {
            return db.Kupac.Include(k => k.KorisnickiRacun).FirstOrDefault(a => a.Id == id);
        }

        public List<Kupac> GetAll()
        {
            return db.Kupac.Include(k => k.KorisnickiRacun).ToList();
        }

        public List<Kupac> GetAllByUsername(string username)
        {
            return db.Kupac.Include(k => k.KorisnickiRacun).Where(k => k.KorisnickiRacun.KorisnickoIme == username).ToList();
        }
        public Kupac GetByKorisnickiRacunId(int korisnickiRacunId)
        {
            return db.Kupac.Include(x => x.KorisnickiRacun).FirstOrDefault(x => x.KorisnickiRacunId == korisnickiRacunId);
        }


        public void AddVoziloToFavourites(int voziloId, int kupacId)
        {
            db.VoziloFavorit.Add(new VoziloFavorit { VoziloId = voziloId, KupacId = kupacId });
            db.SaveChanges();
        }

        public List<VoziloFavoritPrikazVM> GetFavorites(int kupacId)
        {
            return db.VoziloFavorit.Include(vf => vf.Vozilo).ThenInclude(v => v.Model).ThenInclude(m => m.Marka)
                                   .Where(vf => vf.KupacId == kupacId)
                                   .Select(vf => new VoziloFavoritPrikazVM
                                   {
                                       Cijena = vf.Vozilo.Cijena.ToString(),
                                       Godiste = vf.Vozilo.GodinaProizvodnje.ToString(),
                                       Id = vf.Vozilo.Id,
                                       Marka = vf.Vozilo.Model.Marka.Naziv,
                                       Model = vf.Vozilo.Model.Naziv
                                   })
                                   .ToList();
        }

        public void UkloniFavorita(int voziloId, int kupacId)
        {
            var voziloFavorit=db.VoziloFavorit.FirstOrDefault(vf => vf.VoziloId == voziloId && vf.KupacId == kupacId);

            db.VoziloFavorit.Remove(voziloFavorit);
            db.SaveChanges();
        }
    }
}
