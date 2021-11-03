namespace ABCar.Models.EntityModels.Korisnici
{
    public class Osoba
    {
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string ImePrezime { get => Ime + " " + Prezime; }

        public string Email { get; set; }

        public int KorisnickiRacunId { get; set; }
        public KorisnickiRacun KorisnickiRacun { get; set; }
    }
}
