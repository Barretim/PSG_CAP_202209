using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp.Model.RH
{
    public class Parceiro : BaseJuridica
    {
        private double desepenho;
        private double comissao;
        private string setor;

        public double Desepenho { get => desepenho; set => desepenho = value; }
        public double Comissao { get => comissao; set => comissao = value; }
        public string Setor { get => setor; set => setor = value; }

        public Parceiro() : base()
        {
        }

        public Parceiro(int id, string cnpj = null, string inscricaoEstadual = null, DateTime fundacao = default, string nomeFantasia = null, string razaoSocial = null, string emailCorporativo = null, double desepenho = 0, double comissao = 0, string setor = null) : base(id, cnpj, inscricaoEstadual, fundacao, nomeFantasia, razaoSocial, emailCorporativo)
        {
            this.desepenho = desepenho;
            this.comissao = comissao;
            this.setor = setor;
        }

       
    }
}
