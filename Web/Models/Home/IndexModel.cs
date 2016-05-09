using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Home
{
    public class IndexModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string NomeCompleto
        {
            get
            {
                return string.Format("{0} {1}", Nome, Sobrenome);
            }
        }
    }
}