using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dominio.RH
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

        public Parceiro(double desepenho, double comissao, string setor)
        {
            this.desepenho = desepenho;
            this.comissao = comissao;
            this.setor = setor;
        }
    }
}
