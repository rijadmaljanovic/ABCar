using ABCar.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ABCar.Models.EntityModels.Korisnici;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using static ABCar.DAL.DBInitializer;

namespace ABCar.DAL.Repositories
{
    public  class ZaposlenikRepository
    {
        private MojDBContext db { get; set; }

        public ZaposlenikRepository()
        {
            db = GetDBInstance();
        }

        public  void Add(Zaposlenik x)
        {
                db.Zaposlenik.Add(x);
                db.SaveChanges();
           
        }

        public  void Remove(Zaposlenik x)
        {
                db.Zaposlenik.Remove(x);
                db.SaveChanges();
            
        }

        public  void Update(Zaposlenik x)
        {
                db.Zaposlenik.Update(x);
                db.SaveChanges();
           
        }

        public  Zaposlenik GetById(int id)
        {
                return db.Zaposlenik.Include(k => k.KorisnickiRacun).FirstOrDefault(a => a.Id == id);
        }

        public  List<Zaposlenik> GetAll()
        {
                return db.Zaposlenik.Include(k => k.KorisnickiRacun).ToList();
        }

        public  List<Zaposlenik> GetAllByUsername(string username)
        {
                return db.Zaposlenik.Include(k => k.KorisnickiRacun).Where(k => k.KorisnickiRacun.KorisnickoIme == username).ToList();
        }
        public Zaposlenik GetByKorisnickiRacunId(int korisnickiRacunId)
        {
            return db.Zaposlenik.Include(x => x.KorisnickiRacun).FirstOrDefault(x => x.KorisnickiRacunId == korisnickiRacunId);
        }
    }
}
