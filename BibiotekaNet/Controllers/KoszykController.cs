using BibiotekaNet.Biznesowa_Warstwa;
using BibiotekaNet.ViewModel.Koszyk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibiotekaNet.Controllers
{
    [Authorize]
    public class KoszykController : Controller
    {
        // GET: Koszyk
        public ActionResult DodajDoKoszyka(int id)
        {
            KoszykBL koszykBL = new KoszykBL();
            koszykBL.DodajDoKoszyka(id);
            return RedirectToAction("Index");
        }

        public ActionResult UsunZKoszyka(int id)
        {
            KoszykBL koszykBL = new KoszykBL();
            koszykBL.UsunZKoszyka(id);
            return RedirectToAction("Index");
        }

        public ActionResult OproznijKoszyk ()
        {
            KoszykBL koszykBL = new KoszykBL();
            koszykBL.OproznijKosz();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            KoszykBL koszykBL = new KoszykBL();
            if(koszykBL.IloscElementowWKoszyku() == 0)
            {
                ViewBag.informacja = "Koszyk jest pusty";
            }
            IndexKoszykVM indexKoszykVM = new IndexKoszykVM();
            indexKoszykVM.ksiazkas = koszykBL.GetKoszyk();
            return View(indexKoszykVM);
        }
    }
}