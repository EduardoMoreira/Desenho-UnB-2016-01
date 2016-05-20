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
    public class SojaController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: Soja
        public ActionResult Index()
        {
            return View(db.Sojas.ToList());
        }

        // GET: Soja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soja soja = db.Sojas.Find(id);
            if (soja == null)
            {
                return HttpNotFound();
            }
            return View(soja);
        }

        // GET: Soja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Soja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CDSoja,NRQuantidade,DTAtualizacao")] Soja soja)
        {
            if (ModelState.IsValid)
            {
                db.Sojas.Add(soja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soja);
        }

        // GET: Soja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soja soja = db.Sojas.Find(id);
            if (soja == null)
            {
                return HttpNotFound();
            }
            return View(soja);
        }

        // POST: Soja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CDSoja,NRQuantidade,DTAtualizacao")] Soja soja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soja);
        }

        // GET: Soja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soja soja = db.Sojas.Find(id);
            if (soja == null)
            {
                return HttpNotFound();
            }
            return View(soja);
        }

        // POST: Soja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soja soja = db.Sojas.Find(id);
            db.Sojas.Remove(soja);
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
