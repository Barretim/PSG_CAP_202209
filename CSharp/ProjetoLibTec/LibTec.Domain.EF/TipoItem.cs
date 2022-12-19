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
    [Table("TipoItem", Schema = "dbo")]
    public partial class TipoItem
    {
        //[Codigo] [int] IDENTITY(1,1) NOT NULL,
        //[Descricao] [varchar](max) NOT NULL,
        //[Ativo] [bit] NULL,
        //[DataInclusao] [datetime] NULL,
        //[DataAlteracao] [datetime] NULL,
        //[DataExclusao] [datetime] NULL,

        [Key]
        [Column(name: "Codigo")]
        public int CodigoTipoItem { get; set; }

        [Column(name: "Descricao")]
        [Unicode(false)]
        public string Descricao { get; set; } = null!;

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
