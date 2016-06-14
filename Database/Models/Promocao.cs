using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Promocao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPromocao { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Preco { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        public bool Ativa { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }
    }
}
