using System;
using System.ComponentModel.DataAnnotations;

namespace ABCar.Models.EntityModels.Korisnici
{
    public class VerifikacijskiToken
    {
        [Key]
        public string GUID { get; set; }

        public int KorisnickiRacunId { get; set; }
        public KorisnickiRacun KorisnickiRacun { get; set; }

        public DateTime DatumLogiranja { get; set; }
    }
}
