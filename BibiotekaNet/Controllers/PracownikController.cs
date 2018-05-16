using BibiotekaNet.Biznesowa_Warstwa;
using BibiotekaNet.Models;
using BibiotekaNet.ViewModel.Klient;
using BibiotekaNet.ViewModel.Ksiazka;
using BibiotekaNet.ViewModel.Pracownik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibiotekaNet.Controllers
{
    [Authorize(Roles = "PRACOWNIK")]
    public class PracownikController : Controller
    {
        // GET: Pracownik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PanelZarzadzajKsiazkami ()
        {
            return RedirectToAction("Index", "Ksiazkas");
        }
        public ActionResult PanelZarzadzajKlientami()
        {
            return RedirectToAction("Index", "Klients");
        }






        public ActionResult PanelZarzadzajWypozyczeniami()
        {
            KlientBL klientBL = new KlientBL();
            IndexKlientVM indexVM = new IndexKlientVM();
            indexVM.listaKlientow = klientBL.GetListaKlientow();
            return View(indexVM);
        }


        public ActionResult ListaKsiazekDoOddaniaKlienta(int id)
        {
            KlientBL klientBL = new KlientBL();
            KlientEM klientEM = klientBL.GetKlient(id);
            WypozyczenieBL wypozyczenieBL = new WypozyczenieBL();
            ListaKsiazekKlientaVM listaKsiazek = new ListaKsiazekKlientaVM();
            listaKsiazek.listaWypozyczenKlienta = wypozyczenieBL.GetListaKsiazekDoOddania(klientEM);
            listaKsiazek.ImieKlienta = klientEM.ImieKlienta;
            listaKsiazek.NazwiskoKlienta = klientEM.NazwiskoKlienta;
            return View(listaKsiazek);
        }

        public ActionResult ListaKsiazekDoOdbioruKlienta(int id)
        {
            KlientBL klientBL = new KlientBL();
            KlientEM klientEM = klientBL.GetKlient(id);
            WypozyczenieBL wypozyczenieBL = new WypozyczenieBL();
            ListaKsiazekKlientaVM listaKsiazek = new ListaKsiazekKlientaVM();
            listaKsiazek.listaWypozyczenKlienta = wypozyczenieBL.GetListaKsiazekDoOdbioru(klientEM);
            listaKsiazek.ImieKlienta = klientEM.ImieKlienta;
            listaKsiazek.NazwiskoKlienta = klientEM.NazwiskoKlienta;
            return View(listaKsiazek);
        }


        public ActionResult WypozyczKsiazke(int id, int klienID)
        {
            WypozyczenieBL wypozyczenieBL = new WypozyczenieBL();
            wypozyczenieBL.WypozyczKsiazeke(id);
            TempData["Informacja"] = "Operacja powiodła się ";
            return RedirectToAction("ListaKsiazekDoOdbioruKlienta", new { id = klienID });

        }

        public ActionResult ZwrocKsiazke(int id, int klienID)
        {
            WypozyczenieBL wypozyczenieBL = new WypozyczenieBL();
            wypozyczenieBL.ZwrotWypozyczonychKsiazek(id);
            TempData["Informacja"] = "Operacja powiodła się ";
            return RedirectToAction("ListaKsiazekDoOddaniaKlienta", new { id = klienID });
        }
    }
}