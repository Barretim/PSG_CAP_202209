using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Poco
{
    public partial class participanteeventopoco
    {
        public participanteeventopoco()
        {
        }

        public long codigoparticipante { get; set; }
        public int pagamento { get; set; }
        public string sugestao { get; set; } = null!;
        public int? avaliacao { get; set; }
        public long codigoevento { get; set; }
        public long codigousuario { get; set; }
    }
}
