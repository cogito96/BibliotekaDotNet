using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Models
{
    public class PracownikEM : Pracownik
    {
        public PracownikEM() : base() { }
        public PracownikEM(Pracownik pracownik)
        {
            PracownikID = pracownik.PracownikID;
            ImiePracownika = pracownik.ImiePracownika;
            NazwiskoPracownika = pracownik.NazwiskoPracownika;
            PESELPracownika = pracownik.PESELPracownika;
            LoginPracownika = pracownik.LoginPracownika;
            HasloPracownika = pracownik.HasloPracownika;
        }
        
    }
}