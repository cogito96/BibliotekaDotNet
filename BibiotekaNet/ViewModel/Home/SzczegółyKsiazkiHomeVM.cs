using BibiotekaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibiotekaNet.ViewModel.Home
{
    public class SzczegółyKsiazkiHomeVM
    {
        public KsiazkaEM ksiazka { get; set; }
        public bool CzyKsiazkaJestDostepna { get; set; }
    }
}