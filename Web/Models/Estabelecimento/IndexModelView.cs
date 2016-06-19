using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Database.Models;

namespace Web.Models.Estabelecimento
{
    public class IndexModelView
    {
        public Database.Models.Estabelecimento[] Estabelecimentos { get; internal set; }
        [Display(Name = "Pesquisar Estabelecimento:")]
        public string Pesquisa { get; set; }
    }
}