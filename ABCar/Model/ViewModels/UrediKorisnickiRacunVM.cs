using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABCar.Models.ViewModels
{
    public class UrediKorisnickiRacunVM
    {
        public int KorisnickiRacunId { get; set; }

        [Required(ErrorMessage = "Korisnicko ime obavezno!")]
        [Display(Name = "Korisnicko ime")]
        [StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessage = "Korisnicko ime mora sadrzavati minimalno 3 karaktera!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Stara lozinka obavezna!")]
        [Display(Name = "Stara lozinka")]
        [DataType(DataType.Password)]
        public string StaraLozinka { get; set; }

        [Required(ErrorMessage = "Nova lozinka obavezna!")]
        [Display(Name = "Nova lozinka")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Lozinka mora sadrzavati minimalno 5 karaktera!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ponovljena nova lozinka obavezna!")]
        [Display(Name = "Ponovljena nova lozinka")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju!")]
        public string Password2 { get; set; }
    }
}
