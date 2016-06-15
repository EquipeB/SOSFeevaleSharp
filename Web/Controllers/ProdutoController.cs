﻿using Database.Models;
using System;
using System.Collections.Generic;
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
                    .Where(p => p.Nome.Contains(model.Pesquisa) || p.Descricao.Contains(model.Pesquisa))
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
            return View(produto);
        }
    }
}