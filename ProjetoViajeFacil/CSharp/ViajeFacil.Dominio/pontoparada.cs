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
    [Table("ponto_parada", Schema = "dbo")]
    public partial class pontoparada
    {
        [Key]
        [Column(name: "id_ponto_parada")]
        public long codigopontoparada { get; set; }

        [Column(name: "descricao")]
        [Unicode(false)]
        [StringLength(255)]
        public string descricao { get; set; } = null!;

        [Column(name: "latitude")]
        [Unicode(false)]
        [StringLength(255)]
        public string latitude { get; set; } = null!;

        [Column(name: "longitude")]
        [Unicode(false)]
        [StringLength(255)]
        public string longitude { get; set; } = null!;

        [Column(name: "id_rota")]
        public long codigorota { get; set; }
    }
}
