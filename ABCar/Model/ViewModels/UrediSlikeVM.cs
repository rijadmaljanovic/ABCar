using System;
using System.Collections.Generic;
using System.Text;
using ABCar.Models.EntityModels.Vozila;
using Microsoft.AspNetCore.Http;

namespace ABCar.Models.ViewModels
{
    public class UrediSlikeVM
    {
        public int VoziloId { get; set; }

        public List<SlikaVozila> SlikeVozila { get; set; }

        public List<IFormFile> PhotoFiles { get; set;  }
    }
}
