namespace ABCar.Models.EntityModels.Korisnici
{
    public class Kupac :Osoba
    {
        public string Adresa { get; set; }

        public string Telefon { get; set; }
        public string Grad { get; set; }
    }
}
