using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class TipoProduto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoProduto { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
