using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCommerce.Models;
using WebCommerce.Models.Classes;

namespace WebCommerce.Controllers
{
    public class PromocaoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Promocao
        public ActionResult Index()
        {
            return View(db.Promocaos.ToList());
        }

        // GET: Promocao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.Promocaos.Find(id);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(promocao);
        }

        // GET: Promocao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promocao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DescontoPorcentagem,DescontoQuantidade,DataPrazo,Valido,Descricao")] Promocao promocao)
        {
            if (ModelState.IsValid)
            {
                db.Promocaos.Add(promocao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promocao);
        }

        // GET: Promocao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.Promocaos.Find(id);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(promocao);
        }

        // POST: Promocao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DescontoPorcentagem,DescontoQuantidade,DataPrazo,Valido,Descricao")] Promocao promocao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promocao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promocao);
        }

        // GET: Promocao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.Promocaos.Find(id);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(promocao);
        }

        // POST: Promocao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promocao promocao = db.Promocaos.Find(id);
            db.Promocaos.Remove(promocao);
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
