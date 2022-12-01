using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Poco
{
    public class ServicoPoco
    {
        public ServicoPoco()
        {
        }

        public int CodigoServico { get; set; }

        public string Descricao { get; set; } = null!;

        public decimal Preco { get; set; }

        public string? MaterialUsado { get; set; } = null!;

        public int? DenteTratado { get; set; }

        public string? MedidaPreventiva { get; set; } = null!;

        public string? TipoExame { get; set; } = null!;

        public string? TipoServico { get; set; } = null!;

        public bool? Situacao { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int? DenteExtraido { get; set; }

        public int? DenteCanalPar { get; set; }

        public int? CodigoTipoServico { get; set; }
    }
}
