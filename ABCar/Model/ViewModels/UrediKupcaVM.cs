﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABCar.Models.ViewModels
{
    public class UrediKupcaVM
    {
        public int KupacId { get; set; }

        [Required]
        [RegularExpression("[A-Za-z]{3,}", ErrorMessage = "Ime mora sadrzavati minimalno 3 karaktera i poceti sa velikim slovom npr. Hasan")]
        public string Ime { get; set; }

        [Required]
        [RegularExpression("[A-Za-z]{3,}", ErrorMessage = "Prezime mora sadrzavati minimalno 3 karaktera i poceti sa velikim slovom npr. Hasic")]
        public string Prezime { get; set; }

        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 5, ErrorMessage = "Adresa mora sadrzavati minimalno 5 karaktera!")]
        public string Adresa { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Grad mora sadrzavati minimalno 3 karaktera!")]
        public string Grad { get; set; }

        [Required]
        [Display(Name = "Broj telefona")]
        public string BrojTelefona { get; set; }

        [Required]
        [Display(Name = "Email adresa")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Datum registracije na sistem")]
        public string DatumRegistracije { get; set; }
    }
}
