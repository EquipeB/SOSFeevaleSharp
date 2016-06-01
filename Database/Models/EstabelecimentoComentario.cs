using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class EstabelecimentoComentario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstabelecimentoComentario { get; set; }

        public string Comentario { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }

        public virtual Usuario Usuaio { get; set; }
    }
}
