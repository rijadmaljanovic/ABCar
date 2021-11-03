using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.EntityModels.Vozila;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCar.Models.EntityModels
{
    public class Nabavka
    {
        public int Id { get; set; }

        public int VoziloId { get; set; }
        public Vozilo Vozilo { get; set; }

        public int ZaposlenikId { get; set; }
        public Zaposlenik Zaposlenik { get; set; }

        public DateTime DatumNabavke { get; set; }

        public float Cijena { get; set; }
    }
}
