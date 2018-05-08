using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Models
{
    public class Egzemplarz
    {
        public int EgzemplarzID { get; set; }

        public string StanKsiazki { get; set; }

        public int KsiazkaID { get; set; }

        public virtual Ksiazka Ksiazka { get; set; }
    }
}