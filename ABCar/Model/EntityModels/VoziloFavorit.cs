using System;
using System.Collections.Generic;
using System.Text;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.EntityModels.Vozila;

namespace ABCar.Models.EntityModels
{
    public class VoziloFavorit
    {
        public int Id { get; set; }

        public int KupacId { get; set; }
        public Kupac Kupac { get; set; }

        public int VoziloId { get; set; }
        public Vozilo Vozilo { get; set; }
    }
}
