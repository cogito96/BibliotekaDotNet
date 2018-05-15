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
using BibiotekaNet.ViewModel.Klient;

namespace BibiotekaNet.Controllers
{
    [Authorize(Roles = "PRACOWNIK")]
    public class KlientsController : Controller
    {
        private DBKontekst db = new DBKontekst();

        // GET: Klients
        public ActionResult Index()
        {
            KlientBL klientBL = new KlientBL();
            IndexKlientVM indexKlientVM = new IndexKlientVM();
            indexKlientVM.listaKlientow = klientBL.GetListaKlientow();
            return View(indexKlientVM);
        }

        // GET: Klients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KlientBL klientBL = new KlientBL();
            SzczegolyKlientVM szczegolyKlientVM = new SzczegolyKlientVM();
            szczegolyKlientVM.klient = klientBL.GetKlient((int)id);
            if (szczegolyKlientVM.klient == null)
            {
                return HttpNotFound();
            }
            return View(szczegolyKlientVM);
        }

        // GET: Klients/Create
        public ActionResult Create()
        {
            DodajKlientaVM dodajKlientaVM = new DodajKlientaVM();
            return View(dodajKlientaVM);
        }

        // POST: Klients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SzczegolyKlientVM klientVM)
        {
            if (ModelState.IsValid)
            {
                KlientBL klientBL = new KlientBL();
                klientBL.DodajKlienta(klientVM.klient);
                return RedirectToAction("Index");
            }

            return View(klientVM);
        }

        // GET: Klients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KlientBL klientBL = new KlientBL();
            EdytujKlientaVM edytujKlientaVM = new EdytujKlientaVM();
            edytujKlientaVM.klient = klientBL.GetKlient((int)id);
            if (edytujKlientaVM.klient == null)
            {
                return HttpNotFound();
            }
            return View(edytujKlientaVM);
        }

        // POST: Klients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EdytujKlientaVM klientVM)
        {
            if (ModelState.IsValid)
            {
                KlientBL klientBL = new KlientBL();
                klientBL.EdytujKlienta(klientVM.klient);
                return RedirectToAction("Index");
            }
            return View(klientVM);
        }

        // GET: Klients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KlientBL klientBL = new KlientBL();
            SzczegolyKlientVM szczegolyKlientVM = new SzczegolyKlientVM();
            szczegolyKlientVM.klient = klientBL.GetKlient((int)id);
            if (szczegolyKlientVM.klient == null)
            {
                return HttpNotFound();
            }
            return View(szczegolyKlientVM.klient);
        }

        // POST: Klients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KsiazkaBL ksiazkaBL = new KsiazkaBL();
            ksiazkaBL.UsunKsiazke((int)id);
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
