using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Domain.EF
{
    [Table("Autor", Schema = "dbo")]
    public partial class Autor
    {
        //Codigo
        //Nome
        //Ativo
        //DataInclusao
        //DataAlteracao
        //DataExclusao

            [Key]
            [Column(name: "Codigo")]
            public int CodigoAutor { get; set; }

            [Column(name: "Nome")]
            [Unicode(false)]
            public string NomeAutor { get; set; } = null!;

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
