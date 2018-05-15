using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BibiotekaNet.Biznesowa_Warstwa;
using BibiotekaNet.Models;
using BibiotekaNet.ViewModel.Ksiazka;

namespace BibiotekaNet.Controllers
{
    [Authorize(Roles = "PRACOWNIK")]
    public class KsiazkasController : Controller
    {
        private DBKontekst db = new DBKontekst();

        // GET: Ksiazkas
        public ActionResult Index()
        {
            KsiazkaBL ksiazkaBL = new KsiazkaBL();
            IndexKsiazkaVM indexVM = new IndexKsiazkaVM();
            indexVM.listaKsiazek = ksiazkaBL.GetListaKsiazek();
            return View(indexVM);
        }

        // GET: Ksiazkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiazkaBL ksiazkaBL = new KsiazkaBL();
            SzczegolyKsiazkaVM vm = new SzczegolyKsiazkaVM();
            vm.ksiazka = ksiazkaBL.GetKsiazka((int)id);
            if (vm.ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: Ksiazkas/Create
        public ActionResult DodajKsiazke()
        {
            return View();
        }

        // POST: Ksiazkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajKsiazke(DodajKsiazkeVM ksiazkaVM)
        {
            ksiazkaVM.ksiazka.DataDodaniaDoSystemu = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                KsiazkaBL ksiazkaBL = new KsiazkaBL();
                ksiazkaBL.DodajKsiazke(ksiazkaVM.ksiazka);
                return RedirectToAction("Index");
            }
            return View(ksiazkaVM);
        }

        // GET: Ksiazkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiazkaBL ksiazka = new KsiazkaBL();
            EdytujKsiazkeVM vm = new EdytujKsiazkeVM();
            vm.ksiazka  = ksiazka.GetKsiazka((int)id);
            if (vm.ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Ksiazkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(EdytujKsiazkeVM ksiazkaVM)
        {
            if (ModelState.IsValid)
            {
                KsiazkaBL bl = new KsiazkaBL();
                bl.EdytujKsiazke(ksiazkaVM.ksiazka);
                return RedirectToAction("Index");
            }
            return View(ksiazkaVM);
        }

        // GET: Ksiazkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiazkaBL ksiazka = new KsiazkaBL();
            SzczegolyKsiazkaVM vm = new SzczegolyKsiazkaVM();
            vm.ksiazka = ksiazka.GetKsiazka((int)id);
            if (vm.ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Ksiazkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KsiazkaBL ksiazkaBL = new KsiazkaBL();
            ksiazkaBL.UsunKsiazke(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
