using BibiotekaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Biznesowa_Warstwa
{
    public class KoszykBL
    {
        DBKontekst db = new DBKontekst();


        public void DodajDoKoszyka(int id)
        {
            var session = HttpContext.Current.Session;
            var dodanyEgzemplarz = db.Egzemplarze.Where(k => k.Ksiazka.KsiazkaID == id && k.StanKsiazki == EgzemplarzStanKsiazkiEnum.MAGAZYN.ToString()).FirstOrDefault();
            EgzemplarzEM dodanyEgzemplarzEM = new EgzemplarzEM(dodanyEgzemplarz);
            if (dodanyEgzemplarzEM != null)
            {
                if (session["koszyk"] == null)
                {
                    List<EgzemplarzEM> wKoszyku = new List<EgzemplarzEM>();
                    wKoszyku.Add(dodanyEgzemplarzEM);
                    session["koszyk"] = wKoszyku;
                    session["iloscKsiazekWKoszyku"] = 1;
                }
                else
                {
                    List<EgzemplarzEM> wKoszyku = (List<EgzemplarzEM>)session["koszyk"];
                    wKoszyku.Add(dodanyEgzemplarzEM);
                    session["koszyk"] = wKoszyku;
                    session["iloscKsiazekWKoszyku"] = IloscElementowWKoszyku() + 1;
                }
                //dodanyEgzemplarz.StanKsiazki = EgzemplarzStatusWypozyczeniaEnum.POLKA.ToString();
            }
        }

        public int IloscElementowWKoszyku ()
        {
            var session = HttpContext.Current.Session;
            return session["iloscKsiazekWKoszyku"] != null ? (int)session["iloscKsiazekWKoszyku"] : 0;
        }

        public List<KsiazkaEM> GetKoszyk()
        {
            var session = HttpContext.Current.Session;
            KsiazkaBL ksiazkaBL = new KsiazkaBL();
            List<KsiazkaEM> listaKsiazekWKoszyku = new List<KsiazkaEM>();
            if(IloscElementowWKoszyku() != 0)
            {
                foreach (var item in (List<EgzemplarzEM>)session["koszyk"])
                {
                    listaKsiazekWKoszyku.Add(ksiazkaBL.GetKsiazka(item.KsiazkaID));
                }
            }
            return listaKsiazekWKoszyku;
        }

        public void OproznijKosz()
        {
            var session = HttpContext.Current.Session;
            if (session["koszyk"] != null)
            {
                List<EgzemplarzEM> wKoszyku = (List<EgzemplarzEM>)session["koszyk"];
                wKoszyku = null;
                session["koszyk"] = wKoszyku;
                session["iloscKsiazekWKoszyku"] = 0;
            }
        }

        public void UsunZKoszyka(int id)
        {
            var session = HttpContext.Current.Session;
            List<EgzemplarzEM> wKoszyku = (List<EgzemplarzEM>)session["koszyk"];

            //usuwanyEgzemplarz.StanKsiazki = EgzemplarzStatusWypozyczeniaEnum.MAGAZYN.ToString() ;

            wKoszyku.RemoveAll(k => k.KsiazkaID == id);
            session["koszyk"] = wKoszyku;
            session["iloscKsiazekWKoszyku"] = IloscElementowWKoszyku() - 1;

            //   db.SaveChanges();
        }


    }
}