using ABCar.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ABCar.Models.EntityModels.Korisnici;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static ABCar.DAL.DBInitializer;


namespace ABCar.DAL.Repositories
{
    public  class KorisnickiRacunRepository
    {
        private MojDBContext db { get; set; }

        public KorisnickiRacunRepository()
        {
            db = GetDBInstance();
        }

        public  void Add(KorisnickiRacun x)
        {
                db.KorisnickiRacun.Add(x);
                db.SaveChanges();
        }

        public  void Remove(KorisnickiRacun x)
        {
                db.KorisnickiRacun.Remove(x);
                db.SaveChanges();

        }

        public  void Update(KorisnickiRacun x)
        {
                db.KorisnickiRacun.Update(x);
                db.SaveChanges();

        }

        public  KorisnickiRacun GetById(int id)
        {
                return db.KorisnickiRacun.FirstOrDefault(a => a.Id == id);
            
        }

        public  List<KorisnickiRacun> GetAll()
        {
                return db.KorisnickiRacun.ToList();
        }

        public  List<KorisnickiRacun> GetAllByUsername(string username)
        {
                return db.KorisnickiRacun.Where(k => k.KorisnickoIme == username).AsNoTracking().ToList();
        }

        public bool IsUsernameUsed(string username)
        {
            return db.KorisnickiRacun.Any(k => k.KorisnickoIme == username);
        }

        public bool IsUsernameUsed(string username, int korisnickiRacunId)
        {
            return db.KorisnickiRacun.Where(k=>k.Id!=korisnickiRacunId).Any(k => k.KorisnickoIme == username);
        }


    }
}
