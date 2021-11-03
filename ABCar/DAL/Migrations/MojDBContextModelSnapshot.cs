﻿// <auto-generated />
using ABCar.DAL;
using ABCar.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DAL.Migrations
{
    [DbContext(typeof(MojDBContext))]
    partial class MojDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ABCar.Models.EntityModels.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<int>("KorisnickiRacunId");

                    b.Property<string>("Prezime");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiRacunId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Korisnici.KorisnickiRacun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumRegistracije");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Lozinka");

                    b.Property<byte[]>("Salt");

                    b.Property<int>("TipKorisnika");

                    b.HasKey("Id");

                    b.ToTable("KorisnickiRacun");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Korisnici.Kupac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("Email");

                    b.Property<string>("Grad");

                    b.Property<string>("Ime");

                    b.Property<int>("KorisnickiRacunId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiRacunId");

                    b.ToTable("Kupac");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Korisnici.VerifikacijskiToken", b =>
                {
                    b.Property<string>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumLogiranja");

                    b.Property<int>("KorisnickiRacunId");

                    b.HasKey("GUID");

                    b.HasIndex("KorisnickiRacunId");

                    b.ToTable("VerifikacijskiToken");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Korisnici.Zaposlenik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("DatumZaposlenja");

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<int>("KorisnickiRacunId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Slika");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiRacunId");

                    b.ToTable("Zaposlenik");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Nabavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Cijena");

                    b.Property<DateTime>("DatumNabavke");

                    b.Property<int>("VoziloId");

                    b.Property<int>("ZaposlenikId");

                    b.HasKey("Id");

                    b.HasIndex("VoziloId")
                        .IsUnique();

                    b.HasIndex("ZaposlenikId");

                    b.ToTable("Nabavka");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Notifikacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Text");

                    b.Property<bool>("Vidjeno");

                    b.Property<int>("VoziloFavoritId");

                    b.HasKey("Id");

                    b.HasIndex("VoziloFavoritId");

                    b.ToTable("Notifikacija");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Prodaja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<float>("Iznos");

                    b.Property<int>("VoziloId");

                    b.Property<int>("ZaposlenikId");

                    b.HasKey("Id");

                    b.HasIndex("VoziloId")
                        .IsUnique();

                    b.HasIndex("ZaposlenikId");

                    b.ToTable("Prodaja");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.Boja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Boja");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.BrojBrzina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("BrojBrzina");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.BrojVrata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("BrojVrata");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.EmisioniStandard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("EmisioniStandard");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.MarkaVozila", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("LogoImagePath");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("MarkaVozila");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.ModelVozila", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Duzina_m");

                    b.Property<int>("MarkaId");

                    b.Property<string>("Naziv");

                    b.Property<float>("Tezina_t");

                    b.HasKey("Id");

                    b.HasIndex("MarkaId");

                    b.ToTable("ModelVozila");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.SlikaVozila", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImgPath");

                    b.Property<int>("VoziloId");

                    b.HasKey("Id");

                    b.HasIndex("VoziloId");

                    b.ToTable("SlikeVozila");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.TipVozila", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("TipVozila");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.Vozilo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ABS");

                    b.Property<bool>("AUX");

                    b.Property<float?>("Akcija");

                    b.Property<bool>("Alarm");

                    b.Property<bool>("AluFelge");

                    b.Property<bool>("AutoKuka");

                    b.Property<bool>("AutomatskaKlima");

                    b.Property<bool>("Bluetooth");

                    b.Property<int>("BojaId");

                    b.Property<int>("BrojBrzinaId");

                    b.Property<int?>("BrojPrethodnihVlasnika");

                    b.Property<int>("BrojSjedecihMjesta");

                    b.Property<int>("BrojVrataId");

                    b.Property<bool>("CD");

                    b.Property<bool>("CentralnoKljucanje");

                    b.Property<float?>("Cijena")
                        .IsRequired();

                    b.Property<bool>("DaljinskoKljucanje");

                    b.Property<bool>("DvozonskaKlima");

                    b.Property<bool>("ESP");

                    b.Property<bool>("ElPodesavanjeRetrovizora");

                    b.Property<bool>("ElPodesavanjeSjedista");

                    b.Property<bool>("ElPodizaciProzora");

                    b.Property<bool>("ElZastitaProtivKradje");

                    b.Property<int>("EmisioniStandardId");

                    b.Property<int>("GodinaProizvodnje");

                    b.Property<bool>("KoznaSjedista");

                    b.Property<float?>("Kubikaza")
                        .IsRequired();

                    b.Property<bool>("Maglenke");

                    b.Property<bool>("Mat");

                    b.Property<bool>("MehanickaZastitaProtivKradje");

                    b.Property<bool>("Metalik");

                    b.Property<int?>("ModelId")
                        .IsRequired();

                    b.Property<bool>("NaslonjacZaRuku");

                    b.Property<bool>("Navigacija");

                    b.Property<bool>("Novo");

                    b.Property<bool>("ObicnaKlima");

                    b.Property<bool>("PanoramaKrov");

                    b.Property<bool>("ParkingAsistent");

                    b.Property<bool>("ParkingSenzor");

                    b.Property<float?>("PotrosnjaPo100km");

                    b.Property<float?>("PredjeniKilometri");

                    b.Property<bool>("Prodano");

                    b.Property<bool>("PutnoRacunalo");

                    b.Property<DateTime?>("RegistrovanDo");

                    b.Property<bool>("Siber");

                    b.Property<int?>("SifraVozila")
                        .IsRequired();

                    b.Property<bool>("SmartStopSistem");

                    b.Property<int?>("SnagaMotoraKS")
                        .IsRequired();

                    b.Property<float?>("SnagaMotoraKW")
                        .IsRequired();

                    b.Property<bool>("Tempomat");

                    b.Property<int>("TipVozilaId");

                    b.Property<bool>("TipkeNaVolanu");

                    b.Property<bool>("USB");

                    b.Property<float>("VelicinaFelgi");

                    b.Property<int>("VrstaMjenjacaId");

                    b.Property<int>("VrstaMotoraId");

                    b.Property<int>("VrstaPogonaId");

                    b.Property<int>("VrstaSvjetlaId");

                    b.Property<bool>("ZatamnjenaStakla");

                    b.Property<bool>("ZracniJastukBocni");

                    b.Property<bool>("ZracniJastukPrednji");

                    b.Property<int>("brojacZaSlike");

                    b.HasKey("Id");

                    b.HasIndex("BojaId");

                    b.HasIndex("BrojBrzinaId");

                    b.HasIndex("BrojVrataId");

                    b.HasIndex("EmisioniStandardId");

                    b.HasIndex("ModelId");

                    b.HasIndex("TipVozilaId");

                    b.HasIndex("VrstaMjenjacaId");

                    b.HasIndex("VrstaMotoraId");

                    b.HasIndex("VrstaPogonaId");

                    b.HasIndex("VrstaSvjetlaId");

                    b.ToTable("Vozilo");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.VrstaMjenjaca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("VrstaMjenjaca");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.VrstaMotora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("VrstaMotora");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.VrstaPogona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("VrstaPogona");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.VrstaSvjetla", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("VrstaSvjetla");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.VoziloFavorit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KupacId");

                    b.Property<int>("VoziloId");

                    b.HasKey("Id");

                    b.HasIndex("KupacId");

                    b.HasIndex("VoziloId");

                    b.ToTable("VoziloFavorit");
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Administrator", b =>
                {
                    b.HasOne("ABCar.Models.EntityModels.Korisnici.KorisnickiRacun", "KorisnickiRacun")
                        .WithMany()
                        .HasForeignKey("KorisnickiRacunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Korisnici.Kupac", b =>
                {
                    b.HasOne("ABCar.Models.EntityModels.Korisnici.KorisnickiRacun", "KorisnickiRacun")
                        .WithMany()
                        .HasForeignKey("KorisnickiRacunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Korisnici.VerifikacijskiToken", b =>
                {
                    b.HasOne("ABCar.Models.EntityModels.Korisnici.KorisnickiRacun", "KorisnickiRacun")
                        .WithMany()
                        .HasForeignKey("KorisnickiRacunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Korisnici.Zaposlenik", b =>
                {
                    b.HasOne("ABCar.Models.EntityModels.Korisnici.KorisnickiRacun", "KorisnickiRacun")
                        .WithMany()
                        .HasForeignKey("KorisnickiRacunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Nabavka", b =>
                {
                    b.HasOne("ABCar.Models.EntityModels.Vozila.Vozilo", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Korisnici.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Notifikacija", b =>
                {
                    b.HasOne("ABCar.Models.EntityModels.VoziloFavorit", "VoziloFavorit")
                        .WithMany()
                        .HasForeignKey("VoziloFavoritId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Prodaja", b =>
                {
                    b.HasOne("ABCar.Models.EntityModels.Vozila.Vozilo", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Korisnici.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.ModelVozila", b =>
                {
                    b.HasOne("ABCar.Models.EntityModels.Vozila.MarkaVozila", "Marka")
                        .WithMany()
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.SlikaVozila", b =>
                {
                    b.HasOne("ABCar.Models.EntityModels.Vozila.Vozilo", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.Vozila.Vozilo", b =>
                {
                    b.HasOne("ABCar.Models.EntityModels.Vozila.Boja", "Boja")
                        .WithMany()
                        .HasForeignKey("BojaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Vozila.BrojBrzina", "BrojBrzina")
                        .WithMany()
                        .HasForeignKey("BrojBrzinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Vozila.BrojVrata", "BrojVrata")
                        .WithMany()
                        .HasForeignKey("BrojVrataId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Vozila.EmisioniStandard", "EmisioniStandard")
                        .WithMany()
                        .HasForeignKey("EmisioniStandardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Vozila.ModelVozila", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Vozila.TipVozila", "TipVozila")
                        .WithMany()
                        .HasForeignKey("TipVozilaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Vozila.VrstaMjenjaca", "VrstaMjenjaca")
                        .WithMany()
                        .HasForeignKey("VrstaMjenjacaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Vozila.VrstaMotora", "VrstaMotora")
                        .WithMany()
                        .HasForeignKey("VrstaMotoraId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Vozila.VrstaPogona", "VrstaPogona")
                        .WithMany()
                        .HasForeignKey("VrstaPogonaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Vozila.VrstaSvjetla", "VrstaSvjetla")
                        .WithMany()
                        .HasForeignKey("VrstaSvjetlaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ABCar.Models.EntityModels.VoziloFavorit", b =>
                {
                    b.HasOne("ABCar.Models.EntityModels.Korisnici.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ABCar.Models.EntityModels.Vozila.Vozilo", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}