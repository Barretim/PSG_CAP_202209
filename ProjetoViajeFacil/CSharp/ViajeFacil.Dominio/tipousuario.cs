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
    [Table("tipo_usuario", Schema = "dbo")]
    public partial class tipousuario
    {
        [Key]
        [Column(name: "id_tipo_usuario")]
        public long codigotipousuario { get; set; }

        [Column(name: "descricao")]
        [Unicode(false)]
        [StringLength(255)]
        public string descricao { get; set; } = null!;
    }
}

