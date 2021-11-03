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
    public  class AdminRepository
    {
        private MojDBContext db { get; set; }

        public AdminRepository()
        {
            db = GetDBInstance();
        }

        public  void Add(Administrator x)
        {
                db.Administrator.Add(x);
                db.SaveChanges();

        }

        public  void Remove(Administrator x)
        {
                db.Administrator.Remove(x);
                db.SaveChanges();

        }

        public  void Update(Administrator x)
        {
                db.Administrator.Update(x);
                db.SaveChanges();

        }

        public  Administrator Get(int id)
        {
                return db.Administrator.FirstOrDefault(a => a.Id == id);
        }


        public  Administrator GetById(int id)
        {
                return db.Administrator.Include(k => k.KorisnickiRacun).FirstOrDefault(a => a.Id == id);
        }

        public  List<Administrator> GetAll()
        {
                return db.Administrator.Include(k => k.KorisnickiRacun).ToList();
        }

        public  List<Administrator> GetAllByUsername(string username)
        {
                return db.Administrator.Include(k => k.KorisnickiRacun).Where(k => k.KorisnickiRacun.KorisnickoIme == username).ToList();
        }

        public Administrator GetByKorisnickiRacunId(int korisnickiRacunId)
        {
            return db.Administrator.Include(x => x.KorisnickiRacun).FirstOrDefault(x => x.KorisnickiRacunId == korisnickiRacunId);
        }


    }
}
