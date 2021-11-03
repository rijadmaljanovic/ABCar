using System;
using System.Collections.Generic;
using System.Text;
using ABCar.Models.EntityModels;
using static ABCar.DAL.DBInitializer;

namespace ABCar.DAL.Repositories
{
    public class ProdajaRepository
    {
        private MojDBContext db { get; set; }

        public ProdajaRepository()
        {
            db = GetDBInstance();
        }

        public void Add(Prodaja x)
        {
            db.Prodaja.Add(x);
            db.SaveChanges();

        }

        public void Remove(Prodaja x)
        {
            db.Prodaja.Remove(x);
            db.SaveChanges();

        }

    }
}
