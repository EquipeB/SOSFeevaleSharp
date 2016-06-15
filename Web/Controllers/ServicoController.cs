using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ServicoController : Controller
    {
        // GET: Servico
        public ActionResult Index()
        {
            return View(db.TipoProduto);
        }

        public ActionResult Detalhe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProduto tipo = db.TipoProduto.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Produtos = tipo.Produtos;
            return View(tipo);
        }
    }
}