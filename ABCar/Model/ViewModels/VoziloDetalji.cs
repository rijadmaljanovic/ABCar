using System;
using System.Collections.Generic;
using System.Text;
using ABCar.Models.EntityModels.Vozila;

namespace ABCar.Models.ViewModels
{
    public class VoziloDetalji
    {
        public Vozilo Vozilo { get; set; }

        public List<string> Slike { get; set; }

    }
}
