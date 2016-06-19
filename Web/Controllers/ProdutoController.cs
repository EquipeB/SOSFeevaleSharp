using Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models.Produto;

namespace Web.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produtos
        public ActionResult Index(IndexModelView model)
        {
            if (!string.IsNullOrEmpty(model.Pesquisa))
            {
                model.Produtos= db.Produto
                    .Where(p => p.Nome.Contains(model.Pesquisa) || p.Descricao.Contains(model.Pesquisa) || p.TipoProduto.Descricao.Contains(model.Pesquisa))
                    .ToArray();
            } else
            {
                model.Produtos = db.Produto.ToArray();
            }

            return View(model);
        }

        public ActionResult Detalhe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoProduto = produto.TipoProduto.Descricao;
            return View(produto);
        }

        [Authorize]
        public ActionResult Registrar()
        {
            ViewBag.IdEstabelecimento = new SelectList(db.Estabelecimento, "IdEstabelecimento", "Nome");
            ViewBag.IdTipoProduto = new SelectList(db.TipoProduto, "IdTipoProduto", "Descricao");
            return View();
        }

        // POST: EstabelecimentoTeste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar([Bind(Include = "IdProduto,Nome,Descricao,Preco,Foto,Ativo,IdTipoProduto,IdEstabelecimento")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstabelecimento = new SelectList(db.Estabelecimento, "IdEstabelecimento", "Nome");
            ViewBag.IdTipoProduto = new SelectList(db.TipoProduto, "IdTipoProduto", "Descricao");
            return View(produto);
        }

        [Authorize]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstabelecimento = new SelectList(db.Estabelecimento, "IdEstabelecimento", "Nome", produto.IdEstabelecimento);
            ViewBag.IdTipoProduto = new SelectList(db.TipoProduto, "IdTipoProduto", "Descricao", produto.IdTipoProduto);
            return View(produto);
        }

        // POST: EstabelecimentoTeste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "IdProduto,Nome,Descricao,Preco,Foto,Ativo,IdTipoProduto,IdEstabelecimento")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstabelecimento = new SelectList(db.Estabelecimento, "IdEstabelecimento", "Nome", produto.IdEstabelecimento);
            ViewBag.IdTipoProduto = new SelectList(db.TipoProduto, "IdTipoProduto", "Descricao", produto.IdTipoProduto);
            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Deletar(int? idProduto)
        {
            if (idProduto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(idProduto);
            if (produto == null)
            {
                return HttpNotFound();
            }
            db.Produto.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}