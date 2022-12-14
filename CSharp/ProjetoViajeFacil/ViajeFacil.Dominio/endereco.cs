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
     [Table("endereco", Schema = "dbo")]
    public partial class endereco
    {
        [Key]
        [Column(name: "id_endereco")]
        public long codigoendereco { get; set; }

        [Column(name: "rua")]
        [Unicode(false)]
        [StringLength(100)]
        public string rua { get; set; } = null!;

        [Column(name: "numero")]
        public int numero { get; set; }

        [Column(name: "complemento")]
        [Unicode(false)]
        [StringLength(255)]
        public string? complemento { get; set; }

        [Column(name: "bairro")]
        [Unicode(false)]
        [StringLength(100)]
        public string? bairro { get; set; } = null!;

        [Column(name: "cep")]
        [Unicode(false)]
        [StringLength(9)]
        public string cep { get; set; } = null!;

        [Column(name: "id_cidade")]
        public long codigocidade { get; set; }

    }
}
