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
    [Table("usuario", Schema = "dbo")]
    public partial class usuario
    {
        [Key]
        [Column(name: "id_usuario")]
        public long codigousuario { get; set; }

        [Column(name: "nome")]
        [Unicode(false)]
        [StringLength(100)]
        public string nome { get; set; } = null!;

        [Column(name: "email")]
        [Unicode(false)]
        [StringLength(50)]
        public string email { get; set; } = null!;

        [Column(name: "cpf")]
        [Unicode(false)]
        [StringLength(50)]
        public string? cpf { get; set; }

        [Column(name: "telefone")]
        [Unicode(false)]
        [StringLength(50)]
        public string telefone { get; set; } = null!;

        [Column(name: "login")]
        [Unicode(false)]
        [StringLength(50)]
        public string login { get; set; } = null!;

        [Column(name: "senha")]
        [Unicode(false)]
        [StringLength(50)]
        public string senha { get; set; } = null!;

        [Column(name: "id_endereco")]
        public long codigoendereco { get; set; }

        [Column(name: "id_tipo_usuario")]
        public long codigotipousuario { get; set; }

        [Column(name: "id_instituicao")]
        public long codigoinstituicao { get; set; }
    }
}
