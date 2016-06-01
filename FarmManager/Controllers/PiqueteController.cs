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
    public class PiqueteController : Controller
    {
        private FarmContext db = new FarmContext();
        private CriacaoTerra criacaoPiquete = new CriacaoPiquete();

        // GET: /Piquete/
        public ActionResult Index()
        {
            return View(db.Piquetes.ToList());
        }

        // GET: /Piquete/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Piquete piquete = db.Piquetes.Find(id);
            if (piquete == null)
            {
                return HttpNotFound();
            }
            return View(piquete);
        }

        // GET: /Piquete/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Piquete/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CDTerra,NRGadosAlocadas,NRMaximoGados,NRHectares")] Piquete piquete)
        {
            if (ModelState.IsValid)
            {
                criacaoPiquete.criarTerra(piquete);
                return RedirectToAction("Index");
            }

            return View(piquete);
        }

        // GET: /Piquete/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Piquete piquete = db.Piquetes.Find(id);
            if (piquete == null)
            {
                return HttpNotFound();
            }
            return View(piquete);
        }

        // POST: /Piquete/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CDTerra,NRGadosAlocadas,NRMaximoGados,NRHectares")] Piquete piquete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(piquete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(piquete);
        }

        // GET: /Piquete/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Piquete piquete = db.Piquetes.Find(id);
            if (piquete == null)
            {
                return HttpNotFound();
            }
            return View(piquete);
        }

        // POST: /Piquete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Piquete piquete = db.Piquetes.Find(id);
            criacaoPiquete.excluirTerra(piquete);
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
