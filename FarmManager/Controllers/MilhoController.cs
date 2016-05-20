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
    public class MilhoController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: Milho
        public ActionResult Index()
        {
            return View(db.Milhos.ToList());
        }

        // GET: Milho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Milho milho = db.Milhos.Find(id);
            if (milho == null)
            {
                return HttpNotFound();
            }
            return View(milho);
        }

        // GET: Milho/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Milho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CDMilho,NRQuantidade,DTAtualizacao")] Milho milho)
        {
            if (ModelState.IsValid)
            {
                db.Milhos.Add(milho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(milho);
        }

        // GET: Milho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Milho milho = db.Milhos.Find(id);
            if (milho == null)
            {
                return HttpNotFound();
            }
            return View(milho);
        }

        // POST: Milho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CDMilho,NRQuantidade,DTAtualizacao")] Milho milho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(milho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(milho);
        }

        // GET: Milho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Milho milho = db.Milhos.Find(id);
            if (milho == null)
            {
                return HttpNotFound();
            }
            return View(milho);
        }

        // POST: Milho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Milho milho = db.Milhos.Find(id);
            db.Milhos.Remove(milho);
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
