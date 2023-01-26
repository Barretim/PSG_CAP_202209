using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Avaliar.Domain.EF
{
    [Table("Profissao", Schema = "dbo")]
    public partial class Profissao
    {
        [Key]
        [Column(name: "IdProfissao")]
        public int CodigoProfissao { get; set; }

        [Column(name: "Descricao")]
        [Unicode(false)]
        public string Descricao { get; set; } = null!;

        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

        [Column(name: "Ativo")]
        public bool? Situacao { get; set; }

    }
}