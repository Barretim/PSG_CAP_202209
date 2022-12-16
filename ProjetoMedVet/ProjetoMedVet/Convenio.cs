﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MedVet.Domain.EF
{
    [Table("Convenio", Schema = "dbo")]
    public partial class Convenio
    {
            [Key]
            [Column(name: "Codigo")]
            public int CodigoConvenio { get; set; }

            [Column(name: "Descricao")]
            [Unicode(false)]
            public string Descricao { get; set; } = null!;

            [Column(name: "Plano")]
            public int Plano { get; set; }

        [Column(name: "Tarifa", TypeName = "decimal")]
        [Unicode(false)]
        public decimal Tarifa { get; set; }

    }
}
