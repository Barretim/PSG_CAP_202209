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
    [Table("regiao", Schema = "dbo")]
    public partial class regiao
    {
        [Key]
        [Column(name: "id_regiao")]
        public long codigoregiao { get; set; }

        [Column(name: "nome")]
        [Unicode(false)]
        [StringLength(100)]
        public string nome { get; set; } = null!;

        [Column(name: "id_pais")]
        public long codigopais { get; set; }
    }
}
