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
    public class MovimentacaoGraosController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: MovimentacaoGraos
        public ActionResult Index()
        {
            return View(db.MovimentacaoGraos.ToList());
        }

        // GET: MovimentacaoGraos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoGrao movimentacaoGrao = db.MovimentacaoGraos.Find(id);
            if (movimentacaoGrao == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoGrao);
        }

        // GET: MovimentacaoGraos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovimentacaoGraos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CDMovimentacaoGrao,TPGrao,DEMovimentacaoGrao,TPEntradaSaida,NRQuantidade,DTAtualizacao")] MovimentacaoGrao movimentacaoGrao)
        {
            if (ModelState.IsValid)
            {
                Grao grao;
                if (movimentacaoGrao.TPGrao == TipoGrao.Soja)
                    grao = new Soja();
                else
                    grao = new Milho();
                movimentacaoGrao.attach(grao);
                db.MovimentacaoGraos.Add(movimentacaoGrao);
                movimentacaoGrao.notify(movimentacaoGrao.NRQuantidade);
                movimentacaoGrao.DTAtualizacao = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movimentacaoGrao);
        }

        // GET: MovimentacaoGraos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoGrao movimentacaoGrao = db.MovimentacaoGraos.Find(id);
            if (movimentacaoGrao == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoGrao);
        }

        // POST: MovimentacaoGraos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CDMovimentacaoGrao,TPGrao,DEMovimentacaoGrao,TPEntradaSaida,NRQuantidade")] MovimentacaoGrao movimentacaoGrao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimentacaoGrao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movimentacaoGrao);
        }

        // GET: MovimentacaoGraos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoGrao movimentacaoGrao = db.MovimentacaoGraos.Find(id);
            if (movimentacaoGrao == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoGrao);
        }

        // POST: MovimentacaoGraos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovimentacaoGrao movimentacaoGrao = db.MovimentacaoGraos.Find(id);
            db.MovimentacaoGraos.Remove(movimentacaoGrao);
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
