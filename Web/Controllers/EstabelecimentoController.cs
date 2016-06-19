using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models.Estabelecimento;

namespace Web.Controllers
{
    public class EstabelecimentoController : Controller
    {
        // GET: Estabelecimeto
        public ActionResult Index(IndexModelView model)
        {
            if (!string.IsNullOrEmpty(model.Pesquisa))
            {
                model.Estabelecimentos = db.Estabelecimento
                    .Where(p => p.Nome.Contains(model.Pesquisa) || p.Descricao.Contains(model.Pesquisa))
                    .ToArray();
            }
            else
            {
                model.Estabelecimentos = db.Estabelecimento.ToArray();
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Detalhe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Produtos = estabelecimento.Produtos;
            return View(estabelecimento);
        }

        [Authorize]
        public ActionResult Registrar()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar([Bind(Include = "IdEstabelecimento,Nome,Descricao,Foto,Localizacao")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Estabelecimento.Add(estabelecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(estabelecimento);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Deletar(int? idEstabelecimento)
        {
            if (idEstabelecimento == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = db.Estabelecimento.Find(idEstabelecimento);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            db.Estabelecimento.Remove(estabelecimento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}