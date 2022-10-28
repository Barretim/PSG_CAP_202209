using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.FrotaPoco
{
    public class FrotaPoco : BaseCampos
    {
        private string finalidade;

        private string veiculos;

        public string Finalidade { get => finalidade; set => finalidade = value; }
        public string Veiculos { get => veiculos; set => veiculos = value; }

        public FrotaPoco() : base()
        { }
    }
}
