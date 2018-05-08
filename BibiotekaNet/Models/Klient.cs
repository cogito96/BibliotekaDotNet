using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Models
{
    public class Klient
    {
        public int KlientID { get; set; }

        [Required(ErrorMessage = "Imie jest wymagane")]
        public string ImieKlienta { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string NazwiskoKlienta { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        public string MiastoKlienta { get; set; }

        public string UlicaKlienta { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress]
        public string EmailKlienta { get; set; }

        [Required(ErrorMessage = "Numer jest wymagany")]
        public int NumerTelefonuKlienta { get; set; }

        [Required(ErrorMessage = "Login jest wymagany")]
        public string LoginKlient { get; set; }

        [Required(ErrorMessage = "Haslo jest wymagane")]
        [DataType(DataType.Password)]
        public string HasloKlienta { get; set; }

        [Required(ErrorMessage = "PESEL jest wymagany")]
        public long PESEL { get; set; }

        public bool PotwierdzenieRejestracji { get; set; }

        public virtual ICollection<Wypozyczenie> WypożyczeniaKlienta { get; set; }
    }
}