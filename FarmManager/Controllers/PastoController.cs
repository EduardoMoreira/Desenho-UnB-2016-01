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
    public class PastoController : Controller
    {
        private FarmContext db = new FarmContext();
        private CriacaoPasto criacaoPasto = new CriacaoPasto();

        // GET: /Pasto/
        public ActionResult Index()
        {
            return View(db.Pastos.ToList());
        }

        // GET: /Pasto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasto pasto = db.Pastos.Find(id);
            if (pasto == null)
            {
                return HttpNotFound();
            }
            return View(pasto);
        }

        // GET: /Pasto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Pasto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CDTerra,NRGadosAlocadas,NRMaximoGados,NRHectares")] Pasto pasto)
        {
            if (ModelState.IsValid)
            {
                criacaoPasto.criarTerra(pasto);
                return RedirectToAction("Index");
            }

            return View(pasto);
        }

        // GET: /Pasto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasto pasto = db.Pastos.Find(id);
            if (pasto == null)
            {
                return HttpNotFound();
            }
            return View(pasto);
        }

        // POST: /Pasto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CDTerra,NRGadosAlocadas,NRMaximoGados,NRHectares")] Pasto pasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pasto);
        }

        // GET: /Pasto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasto pasto = db.Pastos.Find(id);
            if (pasto == null)
            {
                return HttpNotFound();
            }
            return View(pasto);
        }

        // POST: /Pasto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pasto pasto = db.Pastos.Find(id);
            criacaoPasto.excluirTerra(pasto);
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
