using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ABCar.Models.EntityModels.Vozila;
using static ABCar.DAL.DBInitializer;

namespace ABCar.DAL.Repositories
{
    public class SlikeRepository
    {
        private MojDBContext db { get; set; }

        public SlikeRepository()
        {
            db = GetDBInstance();
        }

        public void Add(SlikaVozila x)
        {
            db.SlikeVozila.Add(x);
            db.SaveChanges();

        }

        public void Remove(SlikaVozila x)
        {
            db.SlikeVozila.Remove(x);
            db.SaveChanges();

        }

        public List<SlikaVozila> GetSlikeByVoziloId(int voziloId)
        {
            return db.SlikeVozila.Where(x => x.VoziloId == voziloId).ToList();
        }

        public SlikaVozila GetSlikaById(int slikaId)
        {
            return db.SlikeVozila.FirstOrDefault(x => x.Id == slikaId);
        }

        public int GetBrojSpremljenihSlikaZaVozilo(int voziloId)
        {
            return db.SlikeVozila.Where(x => x.VoziloId == voziloId).Count();
        }

        public void IzbrisiSveSlike(int voziloId)
        {
            db.SlikeVozila.RemoveRange(db.SlikeVozila.Where(x => x.VoziloId == voziloId));
            db.SaveChanges();
        }
    }
}
