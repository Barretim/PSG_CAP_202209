using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Poco
{
    public partial class pontoparadapoco
    {
        public pontoparadapoco()
        {
        }

        public long codigopontoparada { get; set; }
        public string descricao { get; set; } = null!;
        public string latitude { get; set; } = null!;
        public string longitude { get; set; } = null!;
        public long codigorota { get; set; }
    }
}
