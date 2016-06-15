using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduto { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Preco { get; set; }

        public string Foto { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public virtual TipoProduto TipoProduto { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }

        public virtual ICollection<Promocao> Promocoes { get; set; }

        public virtual ICollection<ProdutoComentario> ProdutoComentarios { get; set; }

        public virtual ICollection<ProdutoVoto> ProdutoVotos { get; set; }
    }
}
