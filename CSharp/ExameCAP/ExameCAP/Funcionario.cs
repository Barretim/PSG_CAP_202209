using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameCAP.Dominio.EF
{
    [Table("Funcionario", Schema = "dbo")]
    public partial class Funcionario
    {
        [Key]
        [Column(name: "CodigoFuncionario")]
        public int CodigoPassageiro { get; set; }

        [Column(name: "Matricula")]
        [Unicode(false)]
        [StringLength(50)]
        public string Matricula { get; set; } = null!;

        [Column(name: "ContaCorrente")]
        [Unicode(false)]
        [StringLength(20)]
        public string ContaCorrente { get; set; } = null!;

        [Column(name: "Nome")]
        [Unicode(false)]
        [StringLength(20)]
        public string Nome { get; set; } = null!;

        [Column(name: "Email")]
        [Unicode(false)]
        [StringLength(20)]
        public string Email { get; set; } = null!;

        [Column(name: "Telefone")]
        [Unicode(false)]
        [StringLength(20)]
        public string Telefone { get; set; } = null!;

        [Column(name: "Usuario")]
        [Unicode(false)]
        [StringLength(20)]
        public string Usuario { get; set; } = null!;

        [Column(name: "Senha")]
        [Unicode(false)]
        [StringLength(20)]
        public string Senha { get; set; } = null!;

        [Column(name: "DataNascimento", TypeName = "datetime")]
        public DateTime? DataNascimento { get; set; }
    }
}
