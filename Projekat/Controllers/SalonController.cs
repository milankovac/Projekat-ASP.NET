using System;
using System.Collections.Generic;
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
    public class SalonController : Controller
    {
        private salonDBEntities db = new salonDBEntities();

        // GET: Salon
        public ActionResult Index()
        {
            return View(db.tblSaloni.ToList());
        }

        // GET: Salon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSaloni tblSaloni = db.tblSaloni.Find(id);
            if (tblSaloni == null)
            {
                return HttpNotFound();
            }
            return View(tblSaloni);
        }

        // GET: Salon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,Vlasnik,Adresa,Telefon,Email,WebStranica,PIB,BrojZiroRacuna")] tblSaloni tblSaloni)
        {
            if (ModelState.IsValid)
            {
                db.tblSaloni.Add(tblSaloni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSaloni);
        }

        // GET: Salon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSaloni tblSaloni = db.tblSaloni.Find(id);
            if (tblSaloni == null)
            {
                return HttpNotFound();
            }
            return View(tblSaloni);
        }

        // POST: Salon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,Vlasnik,Adresa,Telefon,Email,WebStranica,PIB,BrojZiroRacuna")] tblSaloni tblSaloni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSaloni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSaloni);
        }

        // GET: Salon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSaloni tblSaloni = db.tblSaloni.Find(id);
            if (tblSaloni == null)
            {
                return HttpNotFound();
            }
            return View(tblSaloni);
        }

        // POST: Salon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSaloni tblSaloni = db.tblSaloni.Find(id);
            db.tblSaloni.Remove(tblSaloni);
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
        public JsonResult pibJedinstven(int pib)
        {
            return Json(!db.tblSaloni.Any(u => u.PIB== pib), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ziroRacunJedinstven(int br)
        {
            return Json(!db.tblSaloni.Any(u => u.BrojZiroRacuna == br), JsonRequestBehavior.AllowGet);
        }
    }
}
