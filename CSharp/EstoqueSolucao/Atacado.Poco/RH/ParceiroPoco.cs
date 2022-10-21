using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.RH
{
    public class ParceiroPoco : BaseJuridica
    {
        private double desepenho;
        private double comissao;
        private string setor;

        public double Desepenho { get => desepenho; set => desepenho = value; }
        public double Comissao { get => comissao; set => comissao = value; }
        public string Setor { get => setor; set => setor = value; }

        public ParceiroPoco() : base()
        {
        }
    }
}
