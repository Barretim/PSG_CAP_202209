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
    [Table("rota", Schema = "dbo")]
    public partial class rota
    {
        [Key]
        [Column(name: "id_rota")]
        public long codigorota { get; set; }

        [Column(name: "ponto_inicial")]
        [Unicode(false)]
        [StringLength(255)]
        public string pontoinicial { get; set; } = null!;

        [Column(name: "ponto_final")]
        [Unicode(false)]
        [StringLength(255)]
        public string pontofinal { get; set; } = null!;
    }
}

