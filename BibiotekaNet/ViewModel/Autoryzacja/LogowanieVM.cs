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
        [Display(Name = "Użytkownik")]
        public string login { get; set; }
        [Display(Name = "Hasło")]
        public string haslo { get; set; }
        public TypUzytkownikaEnum typUzytkownika { get; set; }
    }
}