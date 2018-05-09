using BibiotekaNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Biznesowa_Warstwa
{
    public class KlientBL
    {
        DBKontekst db = new DBKontekst();
        public List<KlientEM> GetListaKlientow()
        {
            List<Klient> listaKlientow = db.Klienci.ToList();
            List<KlientEM> listaKlientowEM  = new List<KlientEM>();
            listaKlientow.ForEach(k => { listaKlientowEM.Add(new KlientEM(k)); });
            return listaKlientowEM;
        }
        public void DodajKlienta(KlientEM klient)
        {
            db.Klienci.Add(klient);
            db.SaveChanges();
        }

        public void UsunKlienta(int id)
        {
            db.Klienci.Remove(db.Klienci.Find(id));
            db.SaveChanges();
        }

        public void EdytujKlienta(Klient klient)
        {
            db.Entry(klient).State = EntityState.Modified;
            db.SaveChanges();
        }
        public KlientEM GetKlient(int id)
        {
            KlientEM klient = new KlientEM(db.Klienci.Find(id));
            return klient;
        }
    }
}