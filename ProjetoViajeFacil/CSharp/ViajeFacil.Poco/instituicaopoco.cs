using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Poco
{
    public partial class instituicaopoco
    {
        public instituicaopoco()
        {
        }

        public long codigoinstituicao { get; set; }
        public string nome { get; set; } = null!;
        public string telefone { get; set; } = null!;
        public long codigoendereco { get; set; }
    }
}
