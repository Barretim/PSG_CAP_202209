using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Poco
{
    public partial class cidadepoco
    {
        public cidadepoco()
        {
        }

        public int codigocidade { get; set; }
        public string nome { get; set; } = null!;
        public string codigoibge7 { get; set; } = null!;
        public string uf { get; set; } = null!;
        public int codigoestado { get; set; }



    }
}
