using ABCar.Business.Helpers;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.ViewModels;
using System;

namespace ABCar.Business
{
    public class KorisnickiRacunOperations
    {
        private readonly KorisnickiRacunRepository korisnickiRacunRepository;

        public KorisnickiRacunOperations()
        {
            korisnickiRacunRepository=new KorisnickiRacunRepository();
        }


        public bool IsTacnaLozinka(KorisnickiRacun korisnickiRacun, string lozinka)
        {
            return (korisnickiRacun.Lozinka == PasswordHasher.GetHash(lozinka, korisnickiRacun.Salt)) ;

        }

        public KorisnickiRacun GetByUsernameAndPassword(string username, string password)
        {
            var korisniciSProslijedjenimUsernameom = korisnickiRacunRepository.GetAllByUsername(username);

            if (korisniciSProslijedjenimUsernameom.Count > 0)
            {
                var korRacun = new KorisnickiRacun();

                foreach (var item in korisniciSProslijedjenimUsernameom)
                {
                    korRacun.SetHashedPasswordAndSalt(password, item.Salt);
                    if (item.Lozinka == korRacun.Lozinka)
                        return item;
                }

            }

            return null;

        }

        public KorisnickiRacun GetById(int korisnickiRacunId)
        {
            return korisnickiRacunRepository.GetById(korisnickiRacunId);
        }

        public UrediKorisnickiRacunVM GetUrediVMById(int korisnickiRacunId)
        {
            var korisnickiRacun = korisnickiRacunRepository.GetById(korisnickiRacunId);

            return new UrediKorisnickiRacunVM
            {
                KorisnickiRacunId = korisnickiRacun.Id,
                Username = korisnickiRacun.KorisnickoIme
            };
        }

        public bool UpdateIfOldPasswordMatchAndUpdateSession(UrediKorisnickiRacunVM model)
        {
            var korisnickiRacun = korisnickiRacunRepository.GetById(model.KorisnickiRacunId);

            if (!IsTacnaLozinka(korisnickiRacun, model.StaraLozinka))
                return false;

            korisnickiRacun.KorisnickoIme = model.Username;
            korisnickiRacun.SetHashedPasswordAndSalt(model.Password);

            korisnickiRacunRepository.Update(korisnickiRacun);
            SessionCookieHelper.SetUserToSession(korisnickiRacun);

            return true;

        }

        public bool IsUsernameUsed(string username)
        {
            return korisnickiRacunRepository.IsUsernameUsed(username);
        }

        public bool IsUsernameUsed(string username, int korisnickiRacunId)
        {
            return korisnickiRacunRepository.IsUsernameUsed(username, korisnickiRacunId);
        }

        public static void CreateAdminAccount()
        {
            var admin = new Administrator
            {
                Ime = "Administrator",
                Prezime = "Administrator",
                KorisnickiRacun = new KorisnickiRacun
                {
                    DatumRegistracije = DateTime.Today,
                    KorisnickoIme = "admin"
                }
            };

            admin.KorisnickiRacun.SetHashedPasswordAndSalt("admin");

            new AdminRepository().Add(admin);

        }



    }
}
