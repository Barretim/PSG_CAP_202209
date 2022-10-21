using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp.Model.RH
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

        public Prestador(int id, string cnpj = null, string inscricaoEstadual = null, DateTime fundacao = default, string nomeFantasia = null, string razaoSocial = null, string emailCorporativo = null, DateOnly dataContratoInicio = default, DateOnly dataContratoFinal = default)
            : base(id, cnpj, inscricaoEstadual, fundacao, nomeFantasia, razaoSocial, emailCorporativo)
        {
            this.dataContratoInicio = dataContratoInicio;
            this.dataContratoFinal = dataContratoFinal;
        }

       
    }
}
