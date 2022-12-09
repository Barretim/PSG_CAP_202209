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
    [Table("instituicao", Schema = "dbo")]
    public partial class instituicao
    {
        [Key]
        [Column(name: "id_instituicao")]
        public long codigoinstituicao { get; set; }

        [Column(name: "nome")]
        [Unicode(false)]
        [StringLength(100)]
        public string nome { get; set; } = null!;

        [Column(name: "telefone")]
        [Unicode(false)]
        [StringLength(20)]
        public string telefone { get; set; } = null!;

        [Column(name: "id_endereco")]
        public long codigoendereco { get; set; }
    }
}
