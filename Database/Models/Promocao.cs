using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Promocao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPromocao { get; set; }

        public decimal Preco { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public bool Ativa { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }
    }
}
