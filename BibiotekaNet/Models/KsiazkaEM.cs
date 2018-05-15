using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Models
{
    public class KsiazkaEM : Ksiazka
    {
        public KsiazkaEM() : base() { }
        public KsiazkaEM(Ksiazka ksiazka)
        {
            KsiazkaID = ksiazka.KsiazkaID;
            Tytuł = ksiazka.Tytuł;
            Opis = ksiazka.Opis;
            DataWydania = ksiazka.DataWydania;
            DataDodaniaDoSystemu = ksiazka.DataDodaniaDoSystemu;
            NazwaKategorii = ksiazka.NazwaKategorii;
            ImieAutor = ksiazka.ImieAutor;
            NazwiskoAutor = ksiazka.NazwiskoAutor;
            Egzemplarze = ksiazka.Egzemplarze;
        }


    }
}