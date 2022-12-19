using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Domain.EF
{
    [Table("Item", Schema = "dbo")]
    public partial class Item
    {
        //[Codigo] [int] IDENTITY(1,1) NOT NULL,
        //[Descricao] [varchar](max) NOT NULL,
        //[ISBN] [varchar](255) NOT NULL,
        //[Observacoes] [varchar](max) NOT NULL,
        //[CodigoTipoItem] [int] NOT NULL,
        //[Ativo] [bit] NULL,
        //[DataInclusao] [datetime] NULL,
        //[DataAlteracao] [datetime] NULL,
        //[DataExclusao] [datetime] NULL,

        [Key]
        [Column(name: "Codigo")]
        public int CodigoItem { get; set; }

        [Column(name: "Descricao")]
        [Unicode(false)]
        public string Descricao { get; set; } = null!;

        [Column(name: "ISBN")]
        [Unicode(false)]
        [StringLength(255)]
        public string ISBN { get; set; } = null!;

        [Column(name: "Observacoes")]
        [Unicode(false)]
        public string Observacoes { get; set; } = null!;

        [Column(name: "CodigoTipoItem")]
        public int CodigoTipoItem { get; set; }

        [Column(name: "Ativo")]
        public bool? Ativo { get; set; }

        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

        [Column(name: "DataAlteracao", TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }

        [Column(name: "DataExclusao", TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }

    }
}
