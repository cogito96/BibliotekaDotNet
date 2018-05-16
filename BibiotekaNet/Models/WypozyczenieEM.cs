using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Models
{
    public class WypozyczenieEM : Wypozyczenie
    {
        public WypozyczenieEM() : base() { }
        public WypozyczenieEM(Wypozyczenie wypozycznie)
        {
            WypozyczenieID = wypozycznie.WypozyczenieID;
            DataWypozyczenia = wypozycznie.DataWypozyczenia;
            DataZwrotu = wypozycznie.DataZwrotu;
            StatusWypozyczenia = wypozycznie.StatusWypozyczenia;
            EgzemplarzID = wypozycznie.EgzemplarzID;
            KlientID = wypozycznie.KlientID;
            Egzemplarz = wypozycznie.Egzemplarz;
        }
    }
}