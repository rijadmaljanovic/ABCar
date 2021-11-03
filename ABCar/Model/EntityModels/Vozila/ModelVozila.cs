using System;
using System.Collections.Generic;
using System.Text;

namespace ABCar.Models.EntityModels.Vozila
{
    public class ModelVozila
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public float Duzina_m { get; set; }

        public float Tezina_t { get; set; }

        public int MarkaId { get; set; }
        public MarkaVozila Marka { get; set; }

    }
}
