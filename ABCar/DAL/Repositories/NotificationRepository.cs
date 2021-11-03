using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ABCar.Models.EntityModels;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using static ABCar.DAL.DBInitializer;

namespace ABCar.DAL.Repositories
{
    public class NotificationRepository
    {
        private MojDBContext db { get; set; }

        public NotificationRepository()
        {
            db = GetDBInstance();
        }

        public void setNotificationsForVozilo(int voziloId,string text)
        {
            var vozilaFav = db.VoziloFavorit.Where(vf => vf.VoziloId == voziloId).ToList();

            foreach (var item in vozilaFav)
            {
                db.Notifikacija.Add(new Notifikacija
                {
                    VoziloFavoritId = item.Id,
                    Text = text,
                    Vidjeno = false,
                    DateTime = DateTime.Now
                });
            }


            db.SaveChanges();
        }

        public List<Notifikacija> GetNotificationsForKupac(int kupacId)
        {
            return db.Notifikacija.Include(n => n.VoziloFavorit).Where(n => n.VoziloFavorit.KupacId == kupacId).OrderByDescending(n=>n.DateTime)
                .ToList();
        }

        public int GetNumberOfNewNotifications(int kupacId)
        {
            return db.Notifikacija.Include(n => n.VoziloFavorit)
                .Count(n => n.VoziloFavorit.KupacId == kupacId && n.Vidjeno == false);
        }

        public void SetNotifikacijeVidjene(int kupacId)
        {
            db.Notifikacija.Include(n => n.VoziloFavorit)
                .Where(n => n.VoziloFavorit.KupacId == kupacId).ToList().ForEach(n => n.Vidjeno = true);

            db.SaveChanges();
        }
    }
}
