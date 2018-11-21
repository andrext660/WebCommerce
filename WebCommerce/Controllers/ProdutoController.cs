using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCommerce.Models;
using WebCommerce.Models.Autenticacao;
using WebCommerce.Models.Classes;

namespace WebCommerce.Controllers
{


    
    public class ProdutoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Produto
        //[Authorize(Roles ="View")]

        public ActionResult Index(string Pesquisa = "")
        {
            var p = db.Produtoes.AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisa))
                p = p.Where(c => c.Nome.Contains(Pesquisa));
            p = p.OrderBy(c => c.Nome);

            if (Request.IsAjaxRequest())
                return PartialView("_Produto", p.ToList());
            return View(p.ToList());
        }

        //Metodo que traz a busca do auto complete jquery
        public  JsonResult BuscarProduto(string term)
        {
            var resul = db.Produtoes.Where(x => x.Nome.StartsWith(term)).Select(x => x.Nome).Take(5).ToList();
            return Json(resul, JsonRequestBehavior.AllowGet);
        }

        // GET: Produto/Details/5
       
        public ActionResult Details(int? id, int? idCategoria, int? idPromocao)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Produto produto = db.Produtoes.Find(id);
            var produto = from m in db.Produtoes.Include(c => c.Categoria).Include(c => c.Promocao)
                         where m.Id == id &&
                               m.IdCategoria == idCategoria &&
                               m.IdPromocao == idPromocao
                          select m;
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto.ToList());
        }

		public void adicionarProdutoCarrinho(int idProduto, String email)
		{
			int idCliente = db.Users.Where(a => a.Email == email).FirstOrDefault().Cliente.Id;
			db.Vendas.Where(p => p.IdCliente == idCliente).FirstOrDefault().ListaProdutos.Add(db.Produtoes.Find(idProduto), 1);
			db.Produtoes.Find(idProduto).ListaVendas.Add(db.Vendas.Where(p => p.IdCliente == idCliente).FirstOrDefault());
		}

        // GET: Produto/Create
        [CustomAuthorize(Roles = "Admin")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Preco,QuantidadeDisponivel,Detalhes,IdCategoria,IdPromocao")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtoes.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produto/Edit/5

        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preco,QuantidadeDisponivel,Detalhes,IdCategoria,IdPromocao")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produto/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
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
