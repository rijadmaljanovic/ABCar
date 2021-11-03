using System.Linq;
using ABCar.Models.EntityModels;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.EntityModels.Vozila;
using Microsoft.EntityFrameworkCore;

namespace ABCar.DAL
{
    public class MojDBContext : DbContext
    {

        public MojDBContext(DbContextOptions op) : base(op)
        {
     
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nabavka>()
                .HasIndex(n => n.VoziloId)
                .IsUnique();
            modelBuilder.Entity<Prodaja>()
                .HasIndex(n => n.VoziloId)
                .IsUnique();

            modelBuilder.Entity<MarkaVozila>()
                .Property(p => p.Id)
                .ValueGeneratedNever();

        }

        public DbSet<KorisnickiRacun> KorisnickiRacun { get; set; }
        public DbSet<VerifikacijskiToken> VerifikacijskiToken { get; set; }
        public DbSet<Kupac> Kupac { get; set; }
        public DbSet<Zaposlenik> Zaposlenik { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Nabavka> Nabavka { get; set; }
        public DbSet<Boja> Boja { get; set; }
        public DbSet<BrojBrzina> BrojBrzina { get; set; }
        public DbSet<BrojVrata> BrojVrata { get; set; }
        public DbSet<EmisioniStandard> EmisioniStandard { get; set; }
        public DbSet<MarkaVozila> MarkaVozila { get; set; }
        public DbSet<ModelVozila> ModelVozila { get; set; }
        public DbSet<SlikaVozila> SlikeVozila { get; set; }
        public DbSet<Vozilo> Vozilo { get; set; }
        public DbSet<TipVozila> TipVozila { get; set; }
        public DbSet<VrstaMjenjaca> VrstaMjenjaca { get; set; }
        public DbSet<VrstaMotora> VrstaMotora { get; set; }
        public DbSet<VrstaPogona> VrstaPogona { get; set; }
        public DbSet<VrstaSvjetla> VrstaSvjetla { get; set; }
        public DbSet<Prodaja> Prodaja { get; set; }
        public DbSet<VoziloFavorit> VoziloFavorit { get; set; }
        public DbSet<Notifikacija> Notifikacija { get; set; }


    }
}
