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


        public void DodajDoKoszyka(int id = 2)
        {
            var session = HttpContext.Current.Session;
            var dodanyEgzemplarz = db.Egzemplarze.Where(k => k.Ksiazka.KsiazkaID == id && k.StanKsiazki == "magazyn").FirstOrDefault();
            if(dodanyEgzemplarz != null)
            {
                if (session["koszyk"] == null)
                {
                    List<Egzemplarz> wKoszyku = new List<Egzemplarz>();
                    wKoszyku.Add(dodanyEgzemplarz);
                    session["koszyk"] = wKoszyku;
                    session["iloscKsiazekWKoszyku"] = 1;
                }
                else
                {
                    List<Egzemplarz> wKoszyku = (List<Egzemplarz>)session["koszyk"];
                    wKoszyku.Add(dodanyEgzemplarz);
                    session["koszyk"] = wKoszyku;
                    session["iloscKsiazekWKoszyku"] = IloscElementowWKoszyku() + 1;
                }
            }
        }

        public int IloscElementowWKoszyku ()
        {
            var session = HttpContext.Current.Session;
            return (int)session["iloscKsiazekWKoszyku"];
        }

        public List<Egzemplarz> GetKoszyk()
        {
            var session = HttpContext.Current.Session;
            return (List<Egzemplarz>)session["koszyk"];
        }

        public void OproznijKosz()
        {
            var session = HttpContext.Current.Session;
            if (session["koszyk"] != null)
            {
                List<Egzemplarz> wKoszyku = (List<Egzemplarz>)session["koszyk"];
                wKoszyku = null;
                session["koszyk"] = wKoszyku;
                session["iloscKsiazekWKoszyku"] = 0;
            }
        }

        public void UsunZKoszyka(Egzemplarz usuwanyEgzemplarz)
        {
            var session = HttpContext.Current.Session;
            List<Egzemplarz> wKoszyku = (List<Egzemplarz>)session["koszyk"];

            //         usuwanyEgzemplarz.StanKsiazki = "magazyn";

            wKoszyku.RemoveAll(k => k.EgzemplarzID == usuwanyEgzemplarz.EgzemplarzID);
            session["koszyk"] = wKoszyku;
            session["iloscKsiazekWKoszyku"] = IloscElementowWKoszyku() - 1;

            //   db.SaveChanges();
        }


    }
}