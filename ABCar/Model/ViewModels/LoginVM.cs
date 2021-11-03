using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABCar.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Korisnicko ime obavezno!")]
        [StringLength(maximumLength:20,MinimumLength =3,ErrorMessage = "Korisnicko ime mora sarzavati minimalno 3 karaktera!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lozinka obavezno!")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Lozinka mora sarzavati minimalno 3 karaktera!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }

        public string RequestUrl { get; set; }
    }
}
