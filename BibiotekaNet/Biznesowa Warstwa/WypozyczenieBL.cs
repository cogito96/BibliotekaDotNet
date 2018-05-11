using BibiotekaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibiotekaNet.Biznesowa_Warstwa
{
    [Authorize]
    public class WypozyczenieBL
    {
        public List<WypozyczenieEM> GetHistoriaWypozyczenKlienta(int id)
        {
            DBKontekst db = new DBKontekst();
            List<WypozyczenieEM> listaWypozyczenEM = new List<WypozyczenieEM>();
            List<Wypozyczenie> listaWypozyczen = db.Wypozyczenia.Where(w => w.KlientID == id).ToList();
            listaWypozyczen.ForEach(x => { listaWypozyczenEM.Add(new WypozyczenieEM(x)); });
            return listaWypozyczenEM;
        }
    }
}