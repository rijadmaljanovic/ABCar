using System;
using System.Collections.Generic;
using System.Text;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.EntityModels.Vozila;

namespace ABCar.Models.EntityModels
{
    public class Prodaja
    {
        public int Id { get; set; }

        public int VoziloId { get; set; }
        public Vozilo Vozilo { get; set; }

        public int ZaposlenikId { get; set; }
        public Zaposlenik Zaposlenik { get; set; }

        public DateTime Datum { get; set; }

        public float Iznos { get; set; }

    }
}
