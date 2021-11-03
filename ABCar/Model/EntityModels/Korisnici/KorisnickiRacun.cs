using System;
using ABCar.Models.Shared;

namespace ABCar.Models.EntityModels.Korisnici
{
    public class KorisnickiRacun
    {
        public int Id { get; set; }

        public string KorisnickoIme { get; set; }

        public string Lozinka { get; set; }

        public byte[] Salt { get; set; }

        public DateTime DatumRegistracije { get; set; }

        public TipKorisnika TipKorisnika { get; set; }

    }
}
