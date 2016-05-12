using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarmManager.Models;
using FarmManager.DAL;

namespace FarmManager.Controllers
{
    public class TerraPlantioController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: /TerraPlantio/
        public ActionResult Index()
        {
            return View(db.TerrasPlantios.ToList());
        }

        // GET: /TerraPlantio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerraPlantio terraplantio = db.TerrasPlantios.Find(id);
            if (terraplantio == null)
            {
                return HttpNotFound();
            }
            return View(terraplantio);
        }

        // GET: /TerraPlantio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TerraPlantio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CDTerra,DTPlantio,DTColheita,TPGrao,NRHectares")] TerraPlantio terraplantio)
        {
            if (ModelState.IsValid)
            {
                db.TerrasPlantios.Add(terraplantio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(terraplantio);
        }

        // GET: /TerraPlantio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerraPlantio terraplantio = db.TerrasPlantios.Find(id);
            if (terraplantio == null)
            {
                return HttpNotFound();
            }
            return View(terraplantio);
        }

        // POST: /TerraPlantio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CDTerra,DTPlantio,DTColheita,TPGrao,NRHectares")] TerraPlantio terraplantio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terraplantio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terraplantio);
        }

        // GET: /TerraPlantio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerraPlantio terraplantio = db.TerrasPlantios.Find(id);
            if (terraplantio == null)
            {
                return HttpNotFound();
            }
            return View(terraplantio);
        }

        // POST: /TerraPlantio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TerraPlantio terraplantio = db.TerrasPlantios.Find(id);
            db.TerrasPlantios.Remove(terraplantio);
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
    }
}
