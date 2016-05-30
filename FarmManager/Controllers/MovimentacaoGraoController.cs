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
    public class MovimentacaoGraoController : Controller
    {
        private FarmContext db = new FarmContext();

        // GET: MovimentacaoGraos
        public ActionResult Index()
        {
            return View(db.MovimentacaoGraos.ToList());
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
