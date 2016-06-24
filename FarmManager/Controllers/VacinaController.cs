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
    public class VacinaController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: /Vacina/
        public ActionResult Index()
        {
            return View(db.Vacinas.ToList());
        }

        // GET: /Vacina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacina vacina = db.Vacinas.Find(id);
            if (vacina == null)
            {
                return HttpNotFound();
            }
            return View(vacina);
        }

        // GET: /Vacina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Vacina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CDVacina,DTAplicacao,DEVacina,DEObservacao")] Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                db.Vacinas.Add(vacina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacina);
        }

        // GET: /Vacina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacina vacina = db.Vacinas.Find(id);
            if (vacina == null)
            {
                return HttpNotFound();
            }
            return View(vacina);
        }

        // POST: /Vacina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CDVacina,DTAplicacao,DEVacina,DEObservacao")] Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacina);
        }

        // GET: /Vacina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacina vacina = db.Vacinas.Find(id);
            if (vacina == null)
            {
                return HttpNotFound();
            }
            return View(vacina);
        }

        // POST: /Vacina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacina vacina = db.Vacinas.Find(id);
            db.Vacinas.Remove(vacina);
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
