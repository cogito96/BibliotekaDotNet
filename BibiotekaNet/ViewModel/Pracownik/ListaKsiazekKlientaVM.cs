using BibiotekaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibiotekaNet.ViewModel.Pracownik
{
    public class ListaKsiazekKlientaVM
    {
        public string ImieKlienta { get; set; }
        public string NazwiskoKlienta { get; set; }
        public List<WypozyczenieEM> listaWypozyczenKlienta { get; set; }

    }
}