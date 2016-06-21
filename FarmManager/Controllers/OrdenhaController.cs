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
    public class OrdenhaController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: Ordenha
        public ActionResult Index()
        {
            return View(db.Ordenhas.ToList());
        }

        // GET: Ordenha/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordenha ordenha = db.Ordenhas.Find(id);
            if (ordenha == null)
            {
                return HttpNotFound();
            }
            return View(ordenha);
        }

        // GET: Ordenha/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ordenha/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CDOrdenha,VLLeite,DTOrdenha")] Ordenha ordenha)
        {
            if (ModelState.IsValid)
            {
                db.Ordenhas.Add(ordenha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordenha);
        }

        // GET: Ordenha/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordenha ordenha = db.Ordenhas.Find(id);
            if (ordenha == null)
            {
                return HttpNotFound();
            }
            return View(ordenha);
        }

        // POST: Ordenha/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CDOrdenha,VLLeite,DTOrdenha")] Ordenha ordenha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordenha);
        }

        // GET: Ordenha/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordenha ordenha = db.Ordenhas.Find(id);
            if (ordenha == null)
            {
                return HttpNotFound();
            }
            return View(ordenha);
        }

        // POST: Ordenha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordenha ordenha = db.Ordenhas.Find(id);
            db.Ordenhas.Remove(ordenha);
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
