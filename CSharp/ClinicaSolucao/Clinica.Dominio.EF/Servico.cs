using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Dominio.EF
{
    [Table("Servico", Schema = "dbo")]
    public partial class Servico
    {
		[Key]
		public int CodigoServico { get; set; }

        [Column(name: "Descricao")]
        [Unicode(false)]
        public string Descricao { get; set; } = null!;

        [Column(name:"Preco", TypeName = "decimal")]
        [Unicode(false)]
        public decimal Preco { get; set; }

        [Column(name: "MaterialUsado")]
        [Unicode(false)]
        public string? MaterialUsado { get; set; } = null!;

        [Column(name: "DenteTratado")]
        public int? DenteTratado { get; set; }

        [Column(name: "MedidaPreventiva")]
        [Unicode(false)]
        public string? MedidaPreventiva { get; set; } = null!;

        [Column(name: "TipoExame")]
        [Unicode(false)]
        public string? TipoExame { get; set; } = null!;

        [Column(name: "TipoServico")]
        [Unicode(false)]
        [StringLength(2)]
        public string? TipoServico { get; set; } = null!;

        [Column(name: "Situacao", TypeName = "bit")]
        public bool? Situacao { get; set; }

        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

        [Column(name: "DataAlteracao", TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
