using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class EstabelecimentoComentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstabelecimentoComentario { get; set; }

        [Required]
        [StringLength(4000)]
        [Display(Name = "Comentário")]
        public string Comentario { get; set; }

        [Display(Name = "Estabelecimento")]
        public int IdEstabelecimento { get; set; }

        [Display(Name = "Usuário")]
        public string IdUsuario { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }
        
        public virtual Usuario Usuario { get; set; }
    }
}
