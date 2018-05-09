using BibiotekaNet.Biznesowa_Warstwa;
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
            KoszykBL koszykBL = new KoszykBL();
            koszykBL.DodajDoKoszyka();
            return View();
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