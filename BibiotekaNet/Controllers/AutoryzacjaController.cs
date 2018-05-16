using BibiotekaNet.Biznesowa_Warstwa;
using BibiotekaNet.ViewModel.Autoryzacja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BibiotekaNet.Models;

namespace BibiotekaNet.Controllers
{
    public class AutoryzacjaController : Controller
    {
        // GET: Autoryzacja
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logowanie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logowanie(LogowanieVM vm, string ReturnUrl)
        {
            FormsAuthentication.SignOut();
            AppBL appBL = new AppBL();
            if (appBL.isValidAutoryzacja(vm.login, vm.haslo, vm.typUzytkownika))
            {
                appBL.Zaloguj(vm);
                TempData["Informacja"] = "Witaj na stronie " + vm.login;
                return ReturnUrl != null ? Redirect(ReturnUrl) : Redirect("Index");
            }

            ModelState.AddModelError("Informacja", "Niepoprawna nazwa użytkownika lub hasło");
            return View(vm);
        }

        public ActionResult Logout()
        {
            KoszykBL koszykBL = new KoszykBL();
            koszykBL.OproznijKosz();
            FormsAuthentication.SignOut();
            TempData["Informacja"] = "Miło było Cię gościć";
            return RedirectToAction("Index");
        }
    }
}