using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Models
{
    public class Klient
    {
        public int KlientID { get; set; }

        [DisplayName("Imie")]
        [Required(ErrorMessage = "Imie jest wymagane")]
        public string ImieKlienta { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string NazwiskoKlienta { get; set; }

        [DisplayName("Miasto")]
        [Required(ErrorMessage = "Miasto jest wymagany")]
        public string MiastoKlienta { get; set; }

        [DisplayName("Ulica")]
        [Required(ErrorMessage = "Ulica jest wymagany")]
        public string UlicaKlienta { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress]
        public string EmailKlienta { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "Numer jest wymagany")]
        public int NumerTelefonuKlienta { get; set; }

        [DisplayName("Login")]
        [Required(ErrorMessage = "Login jest wymagany")]
        public string LoginKlient { get; set; }

        [DisplayName("Haslo")]
        [Required(ErrorMessage = "Haslo jest wymagane")]
        [DataType(DataType.Password)]
        public string HasloKlienta { get; set; }

        [Required(ErrorMessage = "PESEL jest wymagany")]
        public long PESEL { get; set; }

        public bool PotwierdzenieRejestracji { get; set; }

        public virtual ICollection<Wypozyczenie> WypożyczeniaKlienta { get; set; }
    }
}