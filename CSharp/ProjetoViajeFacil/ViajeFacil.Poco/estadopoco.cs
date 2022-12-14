using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Poco
{
    public partial class estadopoco
    {
        public estadopoco()
        {
        }

        public long codigoestado { get; set; }
        public string nome { get; set; } = null!;
        public string uf { get; set; } = null!;
        public long codigoregiao { get; set; }
        public long? codigouf { get; set; }
    }
}
