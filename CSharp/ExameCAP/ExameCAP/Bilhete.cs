using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameCAP.Dominio.EF
{
    [Table("Bilhete", Schema = "dbo")]
    public partial class Bilhete
    {
        [Key]
        [Column(name: "CodigoBilhete")]
        public int CodigoBilhete { get; set; }

        [Column(name: "NumeroBilhete")]
        public int NumeroBilhete { get; set; }

        [Column(name: "Assento")]
        [Unicode(false)]
        [StringLength(3)]
        public string Assento { get; set; } = null!;
    }
}
