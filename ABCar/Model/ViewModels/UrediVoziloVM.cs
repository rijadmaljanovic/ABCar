using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ABCar.Models.EntityModels.Vozila;
using ABCar.Models.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABCar.Models.ViewModels
{
    public class UrediVoziloVM
    {
        public Vozilo Vozilo { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public float? NabavnaCijena { get; set; }

        public VoziloRefVrijednosti RefVrijednosti { get; set; }

        public List<IFormFile> PhotosFormFiles { get; set; }

        public string sifraVozilaZaPretragu { get; set; }
    }
}
