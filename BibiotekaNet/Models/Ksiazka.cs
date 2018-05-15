using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Models
{
    public class Ksiazka
    {
        public int KsiazkaID { get; set; }

        [Required(ErrorMessage = "Tytul jest wymagany")]
        public string Tytuł { get; set; }

        public string Opis { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataWydania { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataDodaniaDoSystemu { get; set; }

        [Required(ErrorMessage = "Kategoria jest wymagana")]
        public string NazwaKategorii { get; set; }

        public string ImieAutor { get; set; }

        public string NazwiskoAutor { get; set; }

        public virtual ICollection<Egzemplarz> Egzemplarze { get; set; }
    }
}