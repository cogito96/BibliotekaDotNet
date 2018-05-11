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
                id = 1;
                wypozyczenieBL.GetHistoriaWypozyczenKlienta((int)id).ForEach(x => { wypozyczeniaVM.Add(new KlientWpozyczenieVM(x)); }) ;
            }
            wypozyczenieBL.GetHistoriaWypozyczenKlienta((int)id).ForEach(x => { wypozyczeniaVM.Add(new KlientWpozyczenieVM(x)); }) ;
            return View(wypozyczeniaVM);
        }
    }
}