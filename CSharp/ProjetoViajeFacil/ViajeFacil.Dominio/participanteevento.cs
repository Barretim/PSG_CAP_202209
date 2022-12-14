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
    public partial class participanteevento
    {
        [Key]
        [Column(name: "id_participante")]
        public long codigoparticipante { get; set; }

        [Column(name: "pagamento")]
        public int pagamento { get; set; }

        [Column(name: "sugestao")]
        [Unicode(false)]
        [StringLength(255)]
        public string sugestao { get; set; } = null!;

        [Column(name: "avaliacao")]
        public int? avaliacao { get; set; }

        [Column(name: "id_evento")]
        public long codigoevento { get; set; }

        [Column(name: "id_usuario")]
        public long codigousuario { get; set; }
    }
}
