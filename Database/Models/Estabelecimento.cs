using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Estabelecimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstabelecimento { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        [StringLength(200)]
        public string Localizacao { get; set; }

        public string Foto { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public virtual ICollection<Promocao> Promocoes { get; set; }
    }
}
