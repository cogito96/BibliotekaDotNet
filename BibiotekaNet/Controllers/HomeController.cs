using BibiotekaNet.Biznesowa_Warstwa;
using BibiotekaNet.ViewModel.Home;
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
            return RedirectToAction("BazaKsiazek");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Witaj na stronie, możesz zarezerwować u nas ksiązkę, a po odbiór zapraszamy do oddziału na ulicy xxxxxxx";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Strona kontaktowa";
            return View();
        }


        public ActionResult BazaKsiazek()
        {
            KsiazkaBL ksiazkaBL = new KsiazkaBL();
            IndexKsiazkaVM indexVM = new IndexKsiazkaVM();
            indexVM.listaKsiazek = ksiazkaBL.GetListaKsiazek();
            return View(indexVM);
        }
        public ActionResult SzczególyKsiazki(int id)
        {
            KsiazkaBL ksiazkaBL = new KsiazkaBL();
            SzczegółyKsiazkiHomeVM vm = new SzczegółyKsiazkiHomeVM();
            vm.ksiazka = ksiazkaBL.GetKsiazka(id);
            vm.CzyKsiazkaJestDostepna = ksiazkaBL.DostepnoscKsiazki(id);
            return View(vm);
        }

        public ActionResult Rejestracja()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Rejestracja(RejestracjaVM rejestracjaVM)
        {
            if (ModelState.IsValid)
            {
                KlientBL klientBL = new KlientBL();
                klientBL.DodajKlienta(rejestracjaVM.klient);
                return Redirect("Index");
            }
            ModelState.AddModelError("CredentialError", "Uzupełnij wszystkie pola");
            return View(rejestracjaVM);
        }




        public ActionResult WyslijWiadomosc()
        {
            return View();
        }



        [HttpPost]
        public ActionResult WyslijWiadomosc(string topic, string message)
        {
            DodatkiBL dodatkiBL = new DodatkiBL();
            if(dodatkiBL.isValid(topic,message))
            {
                dodatkiBL.WyślijWiadomosc(topic, message);
                TempData["Informacja"] = "Wiadomosc zostala wyslana";
                return RedirectToAction("Contact");
            }
            ModelState.AddModelError("Informacja", "Bład, uzupełnij wszystkie pola");
            return View();
        }
    }
}