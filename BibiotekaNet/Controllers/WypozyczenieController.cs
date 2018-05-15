using BibiotekaNet.Biznesowa_Warstwa;
using BibiotekaNet.ViewModel.Wypozyczenie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibiotekaNet.Controllers
{
    public class WypozyczenieController : Controller
    {
        // GET: Wypozyczenie
        public ActionResult Index(int? id)
        {
            WypozyczenieBL wypozyczenieBL = new WypozyczenieBL();
            List<KlientWpozyczenieVM> wypozyczeniaVM = new List<KlientWpozyczenieVM>();
            if(id == null)
            {
                KlientBL klientBL = new KlientBL();
                wypozyczenieBL.GetHistoriaWypozyczenKlienta(klientBL.GetZalogowanyKlient().KlientID).ForEach(x => { wypozyczeniaVM.Add(new KlientWpozyczenieVM(x)); }) ;
                return  View(wypozyczeniaVM);
            }
            wypozyczenieBL.GetHistoriaWypozyczenKlienta((int)id).ForEach(x => { wypozyczeniaVM.Add(new KlientWpozyczenieVM(x)); }) ;
            return View(wypozyczeniaVM);
        }
        public ActionResult WypozyczKsiazkiZKoszyka()
        {
            WypozyczenieBL wypozyczenieBL = new WypozyczenieBL();
            wypozyczenieBL.Wypozycz();
            //return RedirectToAction("Index", "Koszyk");
            return RedirectToAction("Index");
        }
    }
}