using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            salonDBEntities db = new salonDBEntities();
            var salonlista = db.tblSaloni.ToList();
            ViewBag.ListaSalona = new SelectList(salonlista ,"ID", "Naziv");
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