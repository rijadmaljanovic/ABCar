using System;
using System.Collections.Generic;
using System.Text;

namespace ABCar.Models.EntityModels
{
    public class Notifikacija
    {
        public int Id { get; set; }

        public int VoziloFavoritId { get; set; }
        public VoziloFavorit VoziloFavorit { get; set; }

        public string Text { get; set; }

        public bool Vidjeno { get; set; }

        public DateTime DateTime { get; set; }

    }
}
