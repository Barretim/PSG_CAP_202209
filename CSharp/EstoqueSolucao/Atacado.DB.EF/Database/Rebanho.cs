using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.DB.EF.Database
{
    [Table("Rebanho", Schema = "dbo")]
    public partial class Rebanho
    {
        //[ID_Rebanho] [int] IDENTITY(1,1) NOT NULL,
        [Key]
        [Column(name: "ID_Rebanho")]
        public int CodigoRebanho { get; set; }

        //[Ano_Ref] [int] NOT NULL,
        [Column(name: "Ano_Ref")]
        public int AnoRef { get; set; }

        //[ID_Municipio] [int] NOT NULL,
        [Column(name: "ID_Municipio")]
        public int CodigoMunicipio { get; set; }

        //[ID_Tipo_Rebanho] [int] NOT NULL,
        [Column(name:"ID_Tipo_Rebanho")]
        public int CodigoTipoRebanho { get; set; }

        //[Tipo_Rebanho] [varchar](max) NOT NULL,
        [Column(name: "Tipo_Rebanho")]
        public string TipoDoRebanho { get; set; } = null!;

        //[Quantidade] [int] NULL,
        [Column(name:"Quantidade")]
        public int? Quantidade { get; set; }

        //[Situacao] [bit] NULL,
        [Column(name:"Situacao")]
        public bool? Situacao { get; set; }

        //[DataInclusao] [datetime] NULL,
        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

        //[DataAlteracao] [datetime] NULL,
        [Column(name: "DataAlteracao", TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }

        //[DataExclusao] [datetime] NULL,
        [Column(name: "DataExclusao", TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}
