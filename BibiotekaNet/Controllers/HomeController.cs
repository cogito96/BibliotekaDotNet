using BibiotekaNet.Biznesowa_Warstwa;
using BibiotekaNet.ViewModel.Ksiazka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibiotekaNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            KsiazkaBL ksiazkaBL = new KsiazkaBL();
            IndexKsiazkaVM indexVM = new IndexKsiazkaVM();
            indexVM.listaKsiazek = ksiazkaBL.GetListaKsiazek();
            return View(indexVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}