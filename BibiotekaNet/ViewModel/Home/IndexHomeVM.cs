using BibiotekaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibiotekaNet.ViewModel.Home
{
    public class IndexHomeVM
    {
        public string LoginKlienta { get; set; }
        public List<KsiazkaEM> listaKsiazek { get; set; }
    }
}