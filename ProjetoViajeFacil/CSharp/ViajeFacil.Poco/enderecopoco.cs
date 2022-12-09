using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Poco
{
    public partial class enderecopoco
    {
        public enderecopoco()
        {
        }

        public long codigoendereco { get; set; }
        public string rua { get; set; } = null!;
        public int numero { get; set; }
        public string? complemento { get; set; }
        public string? bairro { get; set; } = null!;
        public string cep { get; set; } = null!;
        public long codigocidade { get; set; }

    }
}
