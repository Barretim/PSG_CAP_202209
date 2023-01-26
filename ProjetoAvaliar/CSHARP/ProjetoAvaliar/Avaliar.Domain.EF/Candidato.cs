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
    [Table("Candidato", Schema = "dbo")]
    public partial class Candidato
    {
        [Key]
        [Column(name: "IdCandidato")]
        public int CodigoCandidato { get; set; }


        [Column(name: "IdProfissao")]
        public int CodigoProfissao { get; set; }

        [Column(name: "Nome")]
        [Unicode(false)]
        [StringLength(255)]
        public string Nome { get; set; } = null!;

        [Column(name: "Sobrenome")]
        [Unicode(false)]
        [StringLength(255)]
        public string Sobrenome { get; set; } = null!;

        [Column(name: "Email")]
        [Unicode(false)]
        [StringLength(255)]
        public string Email { get; set; } = null!;

        [Column(name: "Ativo")]
        public bool? Situacao { get; set; }

        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

    }
}