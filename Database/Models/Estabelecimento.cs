using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Estabelecimento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstabelecimento { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Localizacao { get; set; }

        public string Foto { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public virtual ICollection<Promocao> Promocoes { get; set; }
    }
}
