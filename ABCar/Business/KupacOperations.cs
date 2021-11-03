using System;
using System.Collections.Generic;
using System.Text;
using ABCar.Business.Helpers;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.Shared;
using ABCar.Models.ViewModels;

namespace ABCar.Business
{
    public class KupacOperations
    {
        private readonly KupacRepository kupacRepository;

        public KupacOperations()
        {
            kupacRepository = new KupacRepository();
        }


        public UrediKupcaVM GetUrediVMById(int kupacId)
        {
            var kupac = kupacRepository.GetById(kupacId);

            return new UrediKupcaVM
            {
                KupacId = kupac.Id,
                Adresa = kupac.Adresa,
                Email = kupac.Email,
                Ime = kupac.Ime,
                Grad = kupac.Grad,
                BrojTelefona = kupac.Telefon,
                Prezime = kupac.Prezime,
                DatumRegistracije = kupac.KorisnickiRacun.DatumRegistracije.ToShortDateString()
            };
        }

        public List<VoziloFavoritPrikazVM> GetFavorite()
        {
            return kupacRepository.GetFavorites(SessionCookieHelper.GetLoggedKupac().Id);
        }

        public void Update(UrediKupcaVM model)
        {
            var kupac = kupacRepository.GetById(model.KupacId);

            kupac.Adresa = model.Adresa;
            kupac.Grad = model.Grad;
            kupac.Email = model.Email;
            kupac.Ime = model.Ime;
            kupac.Prezime = model.Prezime;
            kupac.Telefon = model.BrojTelefona;

            kupacRepository.Update(kupac);
        }

        public void Remove(int kupacId)
        {
            kupacRepository.Remove(kupacRepository.GetById(kupacId));
        }

        public Kupac Register(RegisterVM model)
        {
            var kupac = new Kupac
            {
                Adresa = model.Adresa,
                Email = model.Email,
                Grad = model.Grad,
                Ime = model.Ime,
                Prezime = model.Prezime,
                Telefon = model.BrojTelefona,
                KorisnickiRacun = new KorisnickiRacun
                {
                    KorisnickoIme = model.Username,
                    DatumRegistracije = DateTime.Today,
                    TipKorisnika = TipKorisnika.Kupac
                }
            };

            kupac.KorisnickiRacun.SetHashedPasswordAndSalt(model.Password);

            kupacRepository.Add(kupac);

            return kupac;
        }

        public void AddVoziloToFavourites(int voziloId, int kupacId)
        {
            kupacRepository.AddVoziloToFavourites(voziloId,kupacId);
        }

        public void UkloniFavorita(int voziloId)
        {
            kupacRepository.UkloniFavorita(voziloId, SessionCookieHelper.GetLoggedKupac().Id);
        }
    }
}
