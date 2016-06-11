using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produtos
        public ActionResult Index()
        {
            return View(db.Produto);
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
            return View(produto);
        }
    }
}