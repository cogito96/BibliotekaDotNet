using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Models
{
    public class EgzemplarzEM : Egzemplarz
    {
        public EgzemplarzEM() : base() { }
        public EgzemplarzEM(Egzemplarz egzemplarz)
        {
            EgzemplarzID = egzemplarz.EgzemplarzID;
            StanKsiazki = egzemplarz.StanKsiazki;
            KsiazkaID = egzemplarz.KsiazkaID;
        }
    }
}