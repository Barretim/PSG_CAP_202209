using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dominio.FrotaAtacado
{
    public class Motocicleta : BasePesoCarga
    {
        public Motocicleta() : base()
        { }

        public Motocicleta(int codigo, bool ativo, DateTime dataInclusao, string chassi, string cor, string marca,
            string modelo, string placa, double pesoBruto, double pesoLiquido, double pesoTotal)
            : base(codigo, ativo, dataInclusao, chassi, cor, marca, modelo, placa, pesoBruto, pesoLiquido, pesoTotal)
        { }
    }
}
