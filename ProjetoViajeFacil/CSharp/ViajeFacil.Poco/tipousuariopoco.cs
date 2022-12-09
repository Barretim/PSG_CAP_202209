using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Poco
{
    public partial class tipousuariopoco
    {
        public tipousuariopoco()
        {
        }

        public long codigotipousuario { get; set; }
        public string descricao { get; set; } = null!;
    }
}

