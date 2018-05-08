using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Models
{
    public class Pracownik
    {
        public int PracownikID { get; set; }

        [Required(ErrorMessage = "Imie jest wymagany")]
        public string ImiePracownika { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string NazwiskoPracownika { get; set; }

        [Required(ErrorMessage = "PELSEL jest wymagany")]
        public double PESELPracownika { get; set; }

        [Required(ErrorMessage = "Login jest wymagany")]
        public string LoginPracownika { get; set; }

        [Required(ErrorMessage = "Haslo jest wymagane")]
        [DataType(DataType.Password)]
        public string HasloPracownika { get; set; }
    }
}