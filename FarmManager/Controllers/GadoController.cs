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
using System.Data.Entity.Validation;

namespace FarmManager.Controllers
{
    public class GadoController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: /Gado/
        public ActionResult Index()
        {
            return View(db.Gados.ToList());
        }

        // GET: /Gado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gado gado = db.Gados.Find(id);
            if (gado == null)
            {
                return HttpNotFound();
            }
            return View(gado);
        }

        // GET: /Gado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Gado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include= "NRBrinco,DTNascimento,TPSexo,DTInseminacao,DTDesamamentacao,DTProcriacao,STAtivo")] Gado gado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Gados.Add(gado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao criar gado: " + e.Message);
            }

            return View(gado);
        }

        // GET: /Gado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gado gado = db.Gados.Find(id);
            if (gado == null)
            {
                return HttpNotFound();
            }
            return View(gado);
        }

        // POST: /Gado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include= "NRBrinco,DTNascimento,TPSexo,DTInseminacao,DTDesamamentacao,DTProcriacao,STAtivo")] Gado gado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gado);
        }

        // GET: /Gado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gado gado = db.Gados.Find(id);
            if (gado == null)
            {
                return HttpNotFound();
            }
            return View(gado);
        }

        // POST: /Gado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gado gado = db.Gados.Find(id);
            db.Gados.Remove(gado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Gado/PlanoCicloSemanal
        public ActionResult PlanoCicloSemanal()
        {
            PlanoCiclo plano = new PlanoCicloSemanal();
            IList<IList<Gado>> listaGados = plano.RetornaListaGados();
            return View(listaGados);
        }

        // GET: /Gado/PlanoCicloMensal
        public ActionResult PlanoCicloMensal()
        {
            PlanoCiclo plano = new PlanoCicloMensal();
            IList<IList<Gado>> listaGados = plano.RetornaListaGados();
            return View(listaGados);
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
