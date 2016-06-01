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
            return View(db.Vacas.ToList());
        }

        // GET: /Gado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gado vaca = db.Vacas.Find(id);
            if (vaca == null)
            {
                return HttpNotFound();
            }
            return View(vaca);
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
        public ActionResult Create([Bind(Include="NRBrinco,DTNascimento,TPSexo,DTInseminacao,DTDesamamentacao,DTProcriacao")] Gado vaca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Vacas.Add(vaca);
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
                Console.WriteLine("Erro ao criar vaca: " + e.Message);
            }

            return View(vaca);
        }

        // GET: /Gado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gado vaca = db.Vacas.Find(id);
            if (vaca == null)
            {
                return HttpNotFound();
            }
            return View(vaca);
        }

        // POST: /Gado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="NRBrinco,DTNascimento,TPSexo,DTInseminacao,DTDesamamentacao,DTProcriacao")] Gado vaca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaca);
        }

        // GET: /Gado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gado vaca = db.Vacas.Find(id);
            if (vaca == null)
            {
                return HttpNotFound();
            }
            return View(vaca);
        }

        // POST: /Gado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gado vaca = db.Vacas.Find(id);
            db.Vacas.Remove(vaca);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Gado/PlanoCicloSemanal
        public ActionResult PlanoCicloSemanal()
        {
            PlanoCiclo plano = new PlanoCicloSemanal();
            IList<IList<Gado>> listaVacas = plano.RetornaListaVacas();
            return View(listaVacas);
        }

        // GET: /Gado/PlanoCicloMensal
        public ActionResult PlanoCicloMensal()
        {
            PlanoCiclo plano = new PlanoCicloMensal();
            IList<IList<Gado>> listaVacas = plano.RetornaListaVacas();
            return View(listaVacas);
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
