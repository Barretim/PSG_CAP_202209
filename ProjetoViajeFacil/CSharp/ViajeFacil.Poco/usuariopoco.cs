using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Poco
{
    public partial class usuariopoco
    {
        public usuariopoco()
        {
        }

        public long codigousuario { get; set; }
        public string nome { get; set; } = null!;
        public string email { get; set; } = null!;
        public string? cpf { get; set; }
        public string telefone { get; set; } = null!;
        public string login { get; set; } = null!;
        public string senha { get; set; } = null!;
        public long codigoendereco { get; set; }
        public long codigotipousuario { get; set; }
        public long codigoinstituicao { get; set; }
    }
}
