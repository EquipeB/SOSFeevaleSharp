using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class EstabelecimentoController : Controller
    {
        // GET: Estabelecimeto
        public ActionResult Index()
        {
            return View(db.Estabelecimento);
        }

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
    }
}