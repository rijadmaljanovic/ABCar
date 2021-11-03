using System;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.Shared;

namespace ABCar.Business.Helpers
{
    public static class SessionCookieHelper
    {

        // SESSION OPERATIONS
        public static void SetUserToSession(KorisnickiRacun korisnickiRacun)
        {
            ContextInitializer.GetHttpContext().SetInSession(korisnickiRacun);
        }
        public static KorisnickiRacun GetUserFromSession()
        {
            return ContextInitializer.GetHttpContext().GetFromSession();
        }
        public static void ClearSession()
        {
            ContextInitializer.GetHttpContext().ClearSession();
        }


        // COOKIE OPERATIONS
        public static void SetUserToCookie(KorisnickiRacun korisnickiRacun)
        {
            var token = new VerifikacijskiToken
            {
                DatumLogiranja = DateTime.Now,
                GUID = Guid.NewGuid().ToString(),
                KorisnickiRacunId = korisnickiRacun.Id
            };

            new VerifikacijskiTokenRepository().Add(token);

            ContextInitializer.GetHttpContext().SetToCookie(token.GUID);
        }
        public static KorisnickiRacun GetUserFromCookie()
        {
            var guid = ContextInitializer.GetHttpContext().GetFromCookie();

            if (!String.IsNullOrEmpty(guid))
            {
                return new KorisnickiRacunRepository().GetById(new VerifikacijskiTokenRepository().Get((guid)).KorisnickiRacunId);
            }

            return null;

        }
        public static void ClearCookie()
        {
            ContextInitializer.GetHttpContext().ClearCookie();
        }


        // LOGGED USER OPERATIONS
        public static bool IsUserLoggedIn()
        {
            return GetUserFromSession() != null;
        }
        public static bool IsUserLoggedIn(TipKorisnika tipKorisnika)
        {
            var accFromSession = GetUserFromSession();

            return accFromSession == null ? false : accFromSession.TipKorisnika == tipKorisnika;
        }

        public static Administrator GetLoggedAdministrator()
        {
            var korisnickiRacun = GetUserFromSession();

            if (korisnickiRacun != null && korisnickiRacun.TipKorisnika == TipKorisnika.Administrator)
            {
                var adminRepository = new AdminRepository();

                return adminRepository.GetByKorisnickiRacunId(korisnickiRacun.Id);

            }

            return null;

        }
        public static Zaposlenik GetLoggedZaposlenik()
        {
            var korisnickiRacun = GetUserFromSession();

            if (korisnickiRacun != null && korisnickiRacun.TipKorisnika == TipKorisnika.Zaposlenik)
            {
                var zaposlenikRepository = new ZaposlenikRepository();

                return zaposlenikRepository.GetByKorisnickiRacunId(korisnickiRacun.Id);
            }

            return null;

        }
        public static Kupac GetLoggedKupac()
        {
            var korisnickiRacun = GetUserFromSession();

            if (korisnickiRacun != null && korisnickiRacun.TipKorisnika == TipKorisnika.Kupac)
            {
                var kupacRepository = new KupacRepository();

                return kupacRepository.GetByKorisnickiRacunId(korisnickiRacun.Id);

            }

            return null;

        }

        public static void RefreshSessionAndCookieFromCookie()
        {
            var korisnickiRacun = SessionCookieHelper.GetUserFromCookie();

            if (korisnickiRacun != null)
            {
                SessionCookieHelper.SetUserToSession(korisnickiRacun);
                SessionCookieHelper.SetUserToCookie(korisnickiRacun);

            }
        }
    }
}
