﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class EstabelecimentoVoto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstabelecimentoVoto { get; set; }

        public int Pontos { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}