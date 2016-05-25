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
    public class EquipamentoRuralController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: EquipamentoRural
        public ActionResult Index()
        {
            return View(db.EquipamentosRurais.ToList());
        }

        // GET: EquipamentoRural/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipamentoRural equipamentoRural = db.EquipamentosRurais.Find(id);
            if (equipamentoRural == null)
            {
                return HttpNotFound();
            }
            return View(equipamentoRural);
        }

        // GET: EquipamentoRural/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipamentoRural/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CDEquipamentoRural,VLCompra,DEEquipamentoRural,STAlugado,DTCompra")] EquipamentoRural equipamentoRural)
        {
            if (ModelState.IsValid)
            {
                db.EquipamentosRurais.Add(equipamentoRural);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipamentoRural);
        }

        // GET: EquipamentoRural/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipamentoRural equipamentoRural = db.EquipamentosRurais.Find(id);
            if (equipamentoRural == null)
            {
                return HttpNotFound();
            }
            return View(equipamentoRural);
        }

        // POST: EquipamentoRural/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CDEquipamentoRural,VLCompra,DEEquipamentoRural,STAlugado,DTCompra")] EquipamentoRural equipamentoRural)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipamentoRural).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipamentoRural);
        }

        // GET: EquipamentoRural/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipamentoRural equipamentoRural = db.EquipamentosRurais.Find(id);
            if (equipamentoRural == null)
            {
                return HttpNotFound();
            }
            return View(equipamentoRural);
        }

        // POST: EquipamentoRural/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipamentoRural equipamentoRural = db.EquipamentosRurais.Find(id);
            db.EquipamentosRurais.Remove(equipamentoRural);
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
