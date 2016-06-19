using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Produto
{
    public class IndexModelView
    {
        [Display(Name = "Pesquisar Produto:")]
        public string Pesquisa { get; set; }
        public Database.Models.Produto[] Produtos { get; set; }
    }
}