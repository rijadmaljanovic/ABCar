using ABCar.Models.EntityModels;
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
    public  class VerifikacijskiTokenRepository
    {
        private MojDBContext db { get; set; }

        public VerifikacijskiTokenRepository()
        {
            db = GetDBInstance();
            //
        }

        public  void Add(VerifikacijskiToken x)
        {
                db.VerifikacijskiToken.Add(x);
                db.SaveChanges();

        }

        public  void Remove(VerifikacijskiToken x)
        {
                db.VerifikacijskiToken.Remove(x);
                db.SaveChanges();

        }

        public  void Update(VerifikacijskiToken x)
        {
                db.VerifikacijskiToken.Update(x);
                db.SaveChanges();

        }

        public  VerifikacijskiToken Get(string id)
        {
                return db.VerifikacijskiToken.FirstOrDefault(a => a.GUID == id);
        }
    }
}
