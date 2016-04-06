using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarmManager.Models;

namespace FarmManager.Controllers
{
    public class VacaController : Controller
    {
        private Entities db = new Entities();

        // GET: /Vaca/
        public ActionResult Index()
        {
            return View(db.Vaca.ToList());
        }

        // GET: /Vaca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaca vaca = db.Vaca.Find(id);
            if (vaca == null)
            {
                return HttpNotFound();
            }
            return View(vaca);
        }

        // GET: /Vaca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Vaca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="NRBrinco,DTNascimento,TPSexo,DTInseminacao,DTDesamamentacao,DTProcriacao")] Vaca vaca)
        {
            if (ModelState.IsValid)
            {
                db.Vaca.Add(vaca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vaca);
        }

        // GET: /Vaca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaca vaca = db.Vaca.Find(id);
            if (vaca == null)
            {
                return HttpNotFound();
            }
            return View(vaca);
        }

        // POST: /Vaca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="NRBrinco,DTNascimento,TPSexo,DTInseminacao,DTDesamamentacao,DTProcriacao")] Vaca vaca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaca);
        }

        // GET: /Vaca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaca vaca = db.Vaca.Find(id);
            if (vaca == null)
            {
                return HttpNotFound();
            }
            return View(vaca);
        }

        // POST: /Vaca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaca vaca = db.Vaca.Find(id);
            db.Vaca.Remove(vaca);
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
