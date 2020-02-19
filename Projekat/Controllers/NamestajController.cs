using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Projekat;

namespace Projekat.Controllers
{
    [Authorize]
    public class NamestajController : Controller
    {
        private salonDBEntities db = new salonDBEntities();

        // GET: Namestaj
        public ActionResult Index(string srch)
        {
            var naziv = from n in db.tblKomadNamestaja select n;


            if (!String.IsNullOrEmpty(srch))
            {

                naziv = naziv.Where(n => n.Naziv.Contains(srch));
            }

            
            return View(naziv.ToList());

        }
      

        // GET: Namestaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKomadNamestaja tblKomadNamestaja = db.tblKomadNamestaja.Find(id);
            if (tblKomadNamestaja == null)
            {
                return HttpNotFound();
            }
            return View(tblKomadNamestaja);
        }

        // GET: Namestaj/Create
        public ActionResult Create()
        {
            ViewBag.KategorijaID = new SelectList(db.tblKategorija, "ID", "Naziv");
            ViewBag.SalonID = new SelectList(db.tblSaloni, "ID", "Naziv");
            return View();
        }

        // POST: Namestaj/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Sifra,Naziv,ZemljaProizvodnje,JedinicnaCena,RaspolozivaKolicina,SalonID,KategorijaID,Slika")] tblKomadNamestaja tblKomadNamestaja)
        {
            if (ModelState.IsValid)
            {
                db.tblKomadNamestaja.Add(tblKomadNamestaja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategorijaID = new SelectList(db.tblKategorija, "ID", "Naziv", tblKomadNamestaja.KategorijaID);
            ViewBag.SalonID = new SelectList(db.tblSaloni, "ID", "Naziv", tblKomadNamestaja.SalonID);
            return View(tblKomadNamestaja);
        }

        // GET: Namestaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKomadNamestaja tblKomadNamestaja = db.tblKomadNamestaja.Find(id);
            if (tblKomadNamestaja == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategorijaID = new SelectList(db.tblKategorija, "ID", "Naziv", tblKomadNamestaja.KategorijaID);
            ViewBag.SalonID = new SelectList(db.tblSaloni, "ID", "Naziv", tblKomadNamestaja.SalonID);
            return View(tblKomadNamestaja);
        }

        // POST: Namestaj/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Sifra,Naziv,ZemljaProizvodnje,JedinicnaCena,RaspolozivaKolicina,SalonID,KategorijaID,Slika")] tblKomadNamestaja tblKomadNamestaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKomadNamestaja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategorijaID = new SelectList(db.tblKategorija, "ID", "Naziv", tblKomadNamestaja.KategorijaID);
            ViewBag.SalonID = new SelectList(db.tblSaloni, "ID", "Naziv", tblKomadNamestaja.SalonID);
            return View(tblKomadNamestaja);
        }

        // GET: Namestaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKomadNamestaja tblKomadNamestaja = db.tblKomadNamestaja.Find(id);
            if (tblKomadNamestaja == null)
            {
                return HttpNotFound();
            }
            return View(tblKomadNamestaja);
        }

        // POST: Namestaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblKomadNamestaja tblKomadNamestaja = db.tblKomadNamestaja.Find(id);
            db.tblKomadNamestaja.Remove(tblKomadNamestaja);
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
        public JsonResult sifraJedinstvena(string sifra)
        {
            return Json(!db.tblKomadNamestaja.Any(u => u.Sifra == sifra), JsonRequestBehavior.AllowGet);
        }
    }
}
