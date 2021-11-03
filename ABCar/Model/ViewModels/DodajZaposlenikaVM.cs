using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABCar.Models.ViewModels
{
    public class DodajZaposlenikaVM
    {
        public int? ZaposlenikID { get; set; }

        [Required]
        [RegularExpression("[A-Za-z]{3,}", ErrorMessage = "Ime mora sadrzavati minimalno 3 karaktera i poceti sa velikim slovom npr. Hasan")]
        public string Ime { get; set; }

        [Required]
        [RegularExpression("[A-Za-z]{3,}", ErrorMessage = "Prezime mora sadrzavati minimalno 3 karaktera i poceti sa velikim slovom npr. Hasic")]
        public string Prezime { get; set; }

        [Required]
        [RegularExpression("[0-9]{3,}", ErrorMessage = "JMBG mora sadrzavati minimalno 3 broja!")]
        public string JMBG { get; set; }

        [Required]
        [Display(Name ="Datum zaposljenja")]
        [DataType(DataType.Date)]
        public DateTime DatumZaposljenja { get; set; }

        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 5, ErrorMessage = "Adresa mora sadrzavati minimalno 5 karaktera!")]
        public string Adresa { get; set; }

        [Required]
        [Display(Name = "Broj telefona")]
        [DataType(DataType.PhoneNumber)]
        public string BrojTelefona { get; set; }

        [Required]
        [Display(Name = "Email adresa")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Korisnicko ime")]
        [StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessage = "Korisnicko ime mora sadrzavati minimalno 3 karaktera!")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Lozinka")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Lozinka mora sadrzavati minimalno 5 karaktera!")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Ponovljena lozinka")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju!")]
        public string Password2 { get; set; }
    }
}
