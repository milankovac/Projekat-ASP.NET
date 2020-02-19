using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekat;

namespace Projekat.Controllers
{
    [Authorize]
    public class KategorijaController : Controller
    {
        private salonDBEntities db = new salonDBEntities();
        
        // GET: Kategorija
        [HttpGet]
        public ActionResult Index(string srch)
        {

            var naziv = from n in db.tblKategorija select n;
            if(!String.IsNullOrEmpty(srch))
            {
                naziv = naziv.Where(n => n.Naziv.Contains(srch));
            }
            return View(naziv.ToList());
            
        }

        // GET: Kategorija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKategorija tblKategorija = db.tblKategorija.Find(id);
            if (tblKategorija == null)
            {
                return HttpNotFound();
            }
            return View(tblKategorija);
        }

        // GET: Kategorija/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategorija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,Opis")] tblKategorija tblKategorija)
        {
            if (ModelState.IsValid)
            {
                db.tblKategorija.Add(tblKategorija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblKategorija);
        }

        // GET: Kategorija/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKategorija tblKategorija = db.tblKategorija.Find(id);
            if (tblKategorija == null)
            {
                return HttpNotFound();
            }
            return View(tblKategorija);
        }

        // POST: Kategorija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,Opis")] tblKategorija tblKategorija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKategorija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblKategorija);
        }

        // GET: Kategorija/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKategorija tblKategorija = db.tblKategorija.Find(id);
            if (tblKategorija == null)
            {
                return HttpNotFound();
            }
            return View(tblKategorija);
        }

        // POST: Kategorija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblKategorija tblKategorija = db.tblKategorija.Find(id);
            tblKomadNamestaja[] komadiNamestajaKojiPripadajuKategorijiZaBrisanje
                = db.tblKomadNamestaja.Where(x => x.KategorijaID == tblKategorija.ID).ToArray();
            db.tblKomadNamestaja.RemoveRange(komadiNamestajaKojiPripadajuKategorijiZaBrisanje);
            db.tblKategorija.Remove(tblKategorija);
            db.SaveChanges();
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
        public JsonResult nazivJedinstven(string naziv)
        {
            return Json(!db.tblKategorija.Any(u => u.Naziv == naziv), JsonRequestBehavior.AllowGet);
        }
    }
}
