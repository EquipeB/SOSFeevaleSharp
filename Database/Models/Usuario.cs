using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string NomeUsuario { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Senha { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Nome { get; set; }

        public string Foto { get; set; }

        public virtual Perfil Perfil { get; set; }

        public virtual ICollection<EstabelecimentoVoto> EstabelecimentoVotos { get; set; }

        public virtual ICollection<EstabelecimentoComentario> EstabelecimentoComentarios { get; set; }

        public virtual ICollection<ProdutoComentario> ProdutoComentarios { get; set; }

        public virtual ICollection<ProdutoVoto> ProdutoVotos { get; set; }
    }
}
