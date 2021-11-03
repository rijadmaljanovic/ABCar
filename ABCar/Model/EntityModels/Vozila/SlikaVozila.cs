using System;
using System.Collections.Generic;
using System.Text;

namespace ABCar.Models.EntityModels.Vozila
{
    public class SlikaVozila
    {
        public int Id { get; set; }

        public string ImgPath { get; set; }

        public int VoziloId { get; set; }
        public Vozilo Vozilo { get; set; }
    }
}
