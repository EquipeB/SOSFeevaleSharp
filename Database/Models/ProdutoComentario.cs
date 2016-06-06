using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class ProdutoComentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProdutoComentario { get; set; }

        [Required]
        [StringLength(4000)]
        public string Comentario { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
