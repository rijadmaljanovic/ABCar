using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ABCar.Models.EntityModels;
using static ABCar.DAL.DBInitializer;

namespace ABCar.DAL.Repositories
{
    public class NabavkaRepository
    {
        private MojDBContext db { get; set; }

        public NabavkaRepository()
        {
            db = GetDBInstance();
        }

        public void Add(Nabavka x)
        {
            db.Nabavka.Add(x);
            db.SaveChanges();
        }


        public Nabavka GetNabavkaByVoziloId(int voziloId)
        {
            return db.Nabavka.FirstOrDefault(n => n.VoziloId == voziloId);
        }

        public void Update(Nabavka nabavka)
        {
            db.Nabavka.Update(nabavka);
            db.SaveChanges();
        }
    }
}
