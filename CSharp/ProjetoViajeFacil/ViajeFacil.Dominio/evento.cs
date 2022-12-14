using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.DB.EF
{
    [Table("evento", Schema = "dbo")]
    public partial class evento
    {
        [Key]
        [Column(name: "id_evento")]
        public long codigoevento { get; set; }

        [Column(name: "titulo")]
        [Unicode(false)]
        [StringLength(255)]
        public string titulo { get; set; } = null!;

        [Column(name: "descricao")]
        [Unicode(false)]
        [StringLength(255)]
        public string? descricao { get; set; } = null!;

        [Column(name: "data_ida", TypeName = "date")]
        public DateOnly dataida { get; set; }

        [Column(name: "data_volta", TypeName = "date")]
        public DateOnly datavolta { get; set; }

        [Column(name: "id_instituicao")]
        public long codigoinstituicao { get; set; }

        [Column(name: "id_rota_ida")]
        public long codigorotaida { get; set; }

        [Column(name: "id_rota_volta")]
        public long codigorotavolta { get; set; }

        [Column(name: "id_usuario_responsavel")]
        public long codigousuarioresponsavel { get; set; }
    }
}
