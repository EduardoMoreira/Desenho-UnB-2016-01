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
    public class TerraNuaController : Controller
    {
        private FarmContext db = new FarmContext();
        private CriacaoTerra criacaoTerraNua = new CriacaoTerraNua();

        // GET: /TerraNua/
        public ActionResult Index()
        {
            return View(db.TerrasNuas.ToList());
        }

        // GET: /TerraNua/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerraNua terranua = db.TerrasNuas.Find(id);
            if (terranua == null)
            {
                return HttpNotFound();
            }
            return View(terranua);
        }

        // GET: /TerraNua/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TerraNua/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CDTerra,DETerra,NRHectares")] TerraNua terranua)
        {
            if (ModelState.IsValid)
            {
                criacaoTerraNua.criarTerra(terranua);
                return RedirectToAction("Index");
            }

            return View(terranua);
        }

        // GET: /TerraNua/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerraNua terranua = db.TerrasNuas.Find(id);
            if (terranua == null)
            {
                return HttpNotFound();
            }
            return View(terranua);
        }

        // POST: /TerraNua/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CDTerra,DETerra,NRHectares")] TerraNua terranua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terranua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terranua);
        }

        // GET: /TerraNua/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerraNua terranua = db.TerrasNuas.Find(id);
            if (terranua == null)
            {
                return HttpNotFound();
            }
            return View(terranua);
        }

        // POST: /TerraNua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TerraNua terraNua = db.TerrasNuas.Find(id);
            criacaoTerraNua.excluirTerra(terraNua);
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
