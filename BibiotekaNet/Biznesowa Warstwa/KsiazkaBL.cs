using BibiotekaNet.Models;
using BibiotekaNet.ViewModel.Ksiazka;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Biznesowa_Warstwa
{
    public class KsiazkaBL
    {
        DBKontekst db = new DBKontekst();
        public List<KsiazkaEM> GetListaKsiazek()
        {
            List<Ksiazka> listaKsiazek = db.Ksiazki.ToList();
            List<KsiazkaEM> listaKsiazekEM = new List<KsiazkaEM>();
            listaKsiazek.ForEach(k => { listaKsiazekEM.Add(new KsiazkaEM(k)); });
            return listaKsiazekEM;
        }
        public void DodajKsiazke(KsiazkaEM ksiazka)
        {

            Egzemplarz egzemplarz = new Egzemplarz();
            var szukajTakiejKsiazki = db.Ksiazki.FirstOrDefault(k => k.Tytuł == ksiazka.Tytuł);
            if (szukajTakiejKsiazki == null)
            {
                ksiazka.DataDodaniaDoSystemu = DateTime.Now;   // przypisanie daty
                db.Ksiazki.Add(ksiazka);
            }
            else
                egzemplarz.KsiazkaID = szukajTakiejKsiazki.KsiazkaID;
            egzemplarz.StanKsiazki = EgzemplarzStatusWypozyczeniaEnum.MAGAZYN.ToString();
            db.Egzemplarze.Add(egzemplarz);
            db.SaveChanges();
        }

        public void UsunKsiazke(int id)
        {
            db.Ksiazki.Remove(db.Ksiazki.Find(id));
            db.SaveChanges();
        }

        public void EdytujKsiazke(KsiazkaEM ksiazka)
        {
            db.Entry(ksiazka).State = EntityState.Modified;
            db.SaveChanges();
        }
        public KsiazkaEM GetKsiazka(int id)
        {
            KsiazkaEM ksiazka = new KsiazkaEM(db.Ksiazki.Find(id));
            return ksiazka;
        }
    }
}