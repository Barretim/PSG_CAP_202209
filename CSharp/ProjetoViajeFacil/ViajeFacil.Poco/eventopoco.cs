using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Poco
{
    public partial class eventopoco
    {
        public eventopoco()
        {
        }

        public long codigoevento { get; set; }
        public string titulo { get; set; } = null!;
        public string? descricao { get; set; } = null!;
        public DateOnly dataida { get; set; }
        public DateOnly datavolta { get; set; }
        public long codigoinstituicao { get; set; }
        public long codigorotaida { get; set; }
        public long codigorotavolta { get; set; }
        public long codigousuarioresponsavel { get; set; }
    }
}
