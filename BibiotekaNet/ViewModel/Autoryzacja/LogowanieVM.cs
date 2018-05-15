using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BibiotekaNet.Models;

namespace BibiotekaNet.ViewModel.Autoryzacja
{
    public class LogowanieVM
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login jest wymagany")]
        public string login { get; set; }
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Haslo jest wymagane")]
        public string haslo { get; set; }
        [Display(Name = "Typ uzytkownika")]
        [Required(ErrorMessage = "Wybierz typ uzytkownika")]
        public TypUzytkownikaEnum typUzytkownika { get; set; }
    }
}