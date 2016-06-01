using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class ProdutoVoto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPodutoVoto { get; set; }

        public int Pontos { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
