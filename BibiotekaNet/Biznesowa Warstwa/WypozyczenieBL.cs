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

        public void Wypozycz ()
        {
            DBKontekst db = new DBKontekst();
            KoszykBL koszykBL = new KoszykBL();
            if(koszykBL.IloscElementowWKoszyku() != 0)
            {
                var session = HttpContext.Current.Session;
                foreach (var item in (List<EgzemplarzEM>)session["koszyk"])
                {
                    db.Wypozyczenia.Add(SetWypozyczenie(item));
                    var egzemplarz = db.Egzemplarze.Find(item.EgzemplarzID);
                    egzemplarz.StanKsiazki = EgzemplarzStanKsiazkiEnum.POLKA.ToString();
                    db.SaveChanges();
                }
                koszykBL.OproznijKosz();
            }
        }

        public WypozyczenieEM SetWypozyczenie(EgzemplarzEM egzemplarz)
        {
            WypozyczenieEM wypozyczenie = new WypozyczenieEM();
            KlientBL klientBL = new KlientBL();
            wypozyczenie.KlientID = klientBL.GetZalogowanyKlient().KlientID;                     // zalogowany klient!!!
            wypozyczenie.DataWypozyczenia = DateTime.Today.Date;
            wypozyczenie.EgzemplarzID = egzemplarz.EgzemplarzID;
            wypozyczenie.DataZwrotu = DateTime.Today.AddDays(10);
            wypozyczenie.StatusWypozyczenia = WypozyczenieStatusWypozyczeniaEnum.W_TRAKCIE.ToString();
            return wypozyczenie;
        }
    }


}