using System;
using System.Collections.Generic;
using ABCar.Business.Helpers;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.Shared;
using ABCar.Models.ViewModels;

namespace ABCar.Business
{
    public class ZaposlenikOperations
    {
        private readonly ZaposlenikRepository zaposlenikRepository;
        private readonly KorisnickiRacunRepository korisnickiRacunRepository;


        public ZaposlenikOperations()
        {
            zaposlenikRepository=new ZaposlenikRepository();
            korisnickiRacunRepository=new KorisnickiRacunRepository();
        }

        public void Add(DodajZaposlenikaVM model)
        {
            var noviZaposlenik = new Zaposlenik
            {
                Adresa = model.Adresa,
                DatumZaposlenja = model.DatumZaposljenja,
                Email = model.Email,
                Ime = model.Ime,
                Prezime = model.Prezime,
                JMBG = model.JMBG,
                Telefon = model.BrojTelefona,
                KorisnickiRacun = new KorisnickiRacun
                {
                    KorisnickoIme = model.Username,
                    DatumRegistracije = DateTime.Today,
                    TipKorisnika = TipKorisnika.Zaposlenik
                }
            };

            noviZaposlenik.KorisnickiRacun.SetHashedPasswordAndSalt(model.Password);

            zaposlenikRepository.Add(noviZaposlenik);
        }

        public Zaposlenik GetById(int id)
        {
            return zaposlenikRepository.GetById(id);
        }

        public UrediZaposlenikaVM GetUrediVMById(int zaposlenikId)
        {
            var zaposlenik = zaposlenikRepository.GetById(zaposlenikId);

            return new UrediZaposlenikaVM
            {
                Adresa = zaposlenik.Adresa,
                BrojTelefona = zaposlenik.Telefon,
                DatumZaposljenja = zaposlenik.DatumZaposlenja.ToShortDateString(),
                Email = zaposlenik.Email,
                Ime = zaposlenik.Ime,
                JMBG = zaposlenik.JMBG,
                Prezime = zaposlenik.Prezime,
                ZaposlenikId = zaposlenik.Id
            };

        }

        public void Update(UrediZaposlenikaVM model)
        {
            var zaposlenik = zaposlenikRepository.GetById(model.ZaposlenikId);

            zaposlenik.Adresa = model.Adresa;
            zaposlenik.JMBG = model.JMBG;
            zaposlenik.Telefon = model.BrojTelefona;
            zaposlenik.Email = model.Email;
            zaposlenik.Ime = model.Ime;
            zaposlenik.Prezime = model.Prezime;

            zaposlenikRepository.Update(zaposlenik);
        }

        public void Remove(int zaposlenikId)
        {
            var zaposlenik = zaposlenikRepository.GetById(zaposlenikId);

            var korisnickiRacun = korisnickiRacunRepository.GetById(zaposlenik.KorisnickiRacunId);
            korisnickiRacunRepository.Remove(korisnickiRacun);

        }

        public List<Zaposlenik> GetAll()
        {
            return zaposlenikRepository.GetAll();
        }

    }
}
