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
    public class CupomController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cupom
        public ActionResult Index()
        {
            return View(db.Cupoms.ToList());
        }

        // GET: Cupom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupom cupom = db.Cupoms.Find(id);
            if (cupom == null)
            {
                return HttpNotFound();
            }
            return View(cupom);
        }

        // GET: Cupom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cupom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DescontoQuantidade,DescontoPorcentagem,Valido,Quantidade,Descricao")] Cupom cupom)
        {
            if (ModelState.IsValid)
            {
                db.Cupoms.Add(cupom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cupom);
        }

        // GET: Cupom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupom cupom = db.Cupoms.Find(id);
            if (cupom == null)
            {
                return HttpNotFound();
            }
            return View(cupom);
        }

        // POST: Cupom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DescontoQuantidade,DescontoPorcentagem,Valido,Quantidade,Descricao")] Cupom cupom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cupom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cupom);
        }

        // GET: Cupom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupom cupom = db.Cupoms.Find(id);
            if (cupom == null)
            {
                return HttpNotFound();
            }
            return View(cupom);
        }

        // POST: Cupom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cupom cupom = db.Cupoms.Find(id);
            db.Cupoms.Remove(cupom);
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
