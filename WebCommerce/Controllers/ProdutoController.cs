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

        public ActionResult Index(string prod = "", string cat = "")
        {
            var p = db.Produtoes.AsQueryable().Include(c => c.Categoria).Include(c => c.Promocao);
            if (!string.IsNullOrEmpty(prod) || !string.IsNullOrEmpty(cat))
                p = p.Where(c => c.Nome.Contains(prod) || c.Categoria.Nome.Contains(cat));
            p = p.OrderBy(c => c.Nome);

            if (Request.IsAjaxRequest())
                return PartialView("_Produto", p.ToList());
            ViewBag.Categorias = new SelectList(db.Categorias, "Id", "Nome");
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
            if (id == null || idCategoria == null || idPromocao == null)
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
            return View(produto.FirstOrDefault());
        }

		public String adicionarProdutoCarrinho(int idProduto)
		{
			if (Request.IsAjaxRequest())
			{
				if (!User.Identity.Name.Equals(""))
				{
					String nome = User.Identity.Name.ToString();
					Cliente cliente = db.Clientes.Where(a => a.Nome == nome).FirstOrDefault();
					int idCliente = cliente.Id;
					int idVenda = db.Vendas.Where(a => a.IdCliente == idCliente).FirstOrDefault().Id;
					Produto produto = db.Produtoes.Find(idProduto);
					//adiciona o produto
					if (db.Vendas.Find(idVenda).ListaProdutos.ContainsKey(db.Produtoes.Find(idProduto)))
					{
						//adiciona o produto, qtd+1
						db.Vendas.Find(idVenda).ListaProdutos.Add(produto, db.Vendas.Find(idVenda).ListaProdutos[produto] + 1);
					}
					else
					{
						db.Vendas.Find(idVenda).ListaProdutos.Add(produto, 1);
					}

					//adiciona a venda na lista de produtos
					if (!db.Produtoes.Find(idProduto).ListaVendas.Contains(db.Vendas.Find(idVenda)))
					{
						db.Produtoes.Find(idProduto).ListaVendas.Add(db.Vendas.Where(p => p.IdCliente == idCliente).FirstOrDefault());
					}
					return "Produto Adicionado no carrinho";
				}
				//Mostra a tela de login para o usuário se autenticar
				Response.Redirect("/Account/Login");
			}
				return "Error";
			

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

        [CustomAuthorize(Roles = "Admin")]

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
        [CustomAuthorize(Roles = "Admin")]
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
