using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Models
{
    public class Wypozyczenie
    {
        public int WypozyczenieID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataWypozyczenia { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataZwrotu { get; set; }

        public string StatusWypozyczenia { get; set; }

        public int EgzemplarzID { get; set; }

        public int KlientID { get; set; }

        public virtual Egzemplarz Egzemplarz { get; set; }

        public virtual Klient Klint { get; set; }
    }
}