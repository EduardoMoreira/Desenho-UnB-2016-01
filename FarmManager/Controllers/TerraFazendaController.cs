using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarmManager.DAL;
using FarmManager.Models;

namespace FarmManager.Controllers
{
    public class TerraFazendaController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: TerraFazenda
        public ActionResult Index()
        {
            return View(db.TerraFazenda.ToList());
        }

        // GET: TerraFazenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerraFazenda terraFazenda = db.TerraFazenda.Find(id);
            if (terraFazenda == null)
            {
                return HttpNotFound();
            }
            return View(terraFazenda);
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
