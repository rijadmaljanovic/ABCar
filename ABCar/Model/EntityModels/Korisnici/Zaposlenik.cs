using System;

namespace ABCar.Models.EntityModels.Korisnici
{
    public class Zaposlenik: Osoba
    {
        public string Slika { get; set; }

        public string Adresa { get; set; }

        public string Telefon { get; set; }

        public string JMBG { get; set; }

        public DateTime DatumZaposlenja { get; set; }

    }
}
