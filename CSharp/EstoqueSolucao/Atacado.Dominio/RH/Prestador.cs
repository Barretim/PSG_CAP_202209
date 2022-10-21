using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dominio.RH
{
    public class Prestador : BaseJuridica
    {
        private DateOnly dataContratoInicio;
        private DateOnly dataContratoFinal;

        public DateOnly DataContratoInicio { get => dataContratoInicio; set => dataContratoInicio = value; }
        public DateOnly DataContratoFinal { get => dataContratoFinal; set => dataContratoFinal = value; }

        public Prestador()
        {
        }

        public Prestador(DateOnly dataContratoInicio, DateOnly dataContratoFinal)
        {
            this.dataContratoInicio = dataContratoInicio;
            this.dataContratoFinal = dataContratoFinal;
        }
    }
}
