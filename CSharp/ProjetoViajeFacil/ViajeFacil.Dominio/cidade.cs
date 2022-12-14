using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    [Table("cidade", Schema = "dbo")]
    public partial class cidade
    {
        [Key]
        [Column(name: "id_cidade")]
        public int codigocidade { get; set; }

        [Column(name: "nome")]
        [Unicode(false)]
        [StringLength(100)]
        public string nome { get; set; } = null!;

        [Column(name: "codigo_ibge7")]
        [Unicode(false)]
        public string codigoibge7 { get; set; } = null!;

        [Column(name: "uf")]
        [Unicode(false)]
        [StringLength(2)]
        public string uf { get; set; } = null!;

        [Column(name: "id_estado")]
        public int codigoestado { get; set; }

    }
}
