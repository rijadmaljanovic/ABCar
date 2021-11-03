using System;
using System.Collections.Generic;
using System.Text;
using ABCar.Business.Helpers;
using ABCar.Models.EntityModels;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.Shared;
using ABCar.Models.ViewModels;

namespace ABCar.Business
{
    public class LoginOperations
    {
        private readonly KorisnickiRacunOperations korisnickiRacunOperations;

        public LoginOperations()
        {
            korisnickiRacunOperations = new KorisnickiRacunOperations();
        }

        public KorisnickiRacun LogIn(LoginVM model)
        {
            var korisnickiRacun = korisnickiRacunOperations.GetByUsernameAndPassword(model.Username, model.Password);

            if (korisnickiRacun == null)
                return null;

            SessionCookieHelper.SetUserToSession(korisnickiRacun);
            if (korisnickiRacun.TipKorisnika == TipKorisnika.Kupac && model.RememberMe)
                SessionCookieHelper.SetUserToCookie(korisnickiRacun);

            return korisnickiRacun;
        }

        public LoginVM GetVMForLogin(int korisnickiRacunId)
        {
            return new LoginVM
            {
                RememberMe = true,
                Username = korisnickiRacunId != -1
                    ? korisnickiRacunOperations.GetById(korisnickiRacunId).KorisnickoIme
                    : ""
            };
        }

        public void LogOut()
        {
            if (SessionCookieHelper.IsUserLoggedIn(TipKorisnika.Kupac))
                SessionCookieHelper.ClearCookie();
            SessionCookieHelper.ClearSession();

        }
    }
}
