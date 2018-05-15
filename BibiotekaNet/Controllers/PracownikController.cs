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
    }
}