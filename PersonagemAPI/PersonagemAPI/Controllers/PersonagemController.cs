using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonagemAPI.Models;

namespace PersonagemAPI.Controllers
{
    public class PersonagemController : Controller
    {
        private BancoTCCEntities1 db = new BancoTCCEntities1();

        // GET: Personagem
        public ActionResult Index()
        {
            return View(db.Personagem.ToList());
        }

        // GET: Personagem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.Personagem.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // GET: Personagem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personagem/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Sexo,Classe")] Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                db.Personagem.Add(personagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personagem);
        }

        // GET: Personagem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.Personagem.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // POST: Personagem/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Sexo,Classe")] Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personagem);
        }

        // GET: Personagem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.Personagem.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // POST: Personagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personagem personagem = db.Personagem.Find(id);
            db.Personagem.Remove(personagem);
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
