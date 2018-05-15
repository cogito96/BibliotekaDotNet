using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.Entity;


namespace BibiotekaNet.Models
{
    public class DBKontekst : DbContext 
    {
        public DBKontekst() : base("MyCS") { }

        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Egzemplarz> Egzemplarze { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }

        public System.Data.Entity.DbSet<BibiotekaNet.Models.KlientEM> Klients { get; set; }
    }
}