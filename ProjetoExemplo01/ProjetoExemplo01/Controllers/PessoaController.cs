using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoExemplo01.Models;

namespace ProjetoExemplo01.Controllers
{
    public class PessoaController : Controller
    {
        private PesContext db = new PesContext();
        private IPessoaRepository pessoaRepo;

        public PessoaController()
        {
            this.pessoaRepo = new EFPessoaRepository();
        }

        public PessoaController(IPessoaRepository pessoaRepo)
        {
            this.pessoaRepo = pessoaRepo;
        }

        // GET: Pessoa
        [HttpGet]
        public ViewResult Index()
        {
            return View(pessoaRepo.Pessoas.ToList());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int? id)
        {
            
            return View(pessoaRepo.Details(id));
        }

        //// GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Pessoa/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoaId,First_name,Last_name,Idade")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaRepo.Create(pessoa);
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        //// GET: Pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(pessoaRepo.Edit(id));
        }

        //// POST: Pessoa/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaId,First_name,Last_name,Idade")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaRepo.Edit(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        //// GET: Pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(pessoaRepo.Delete(id));
        }

        //// POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pessoaRepo.ConfirmDelete(id);
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
