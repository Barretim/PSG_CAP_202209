using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dominio.FrotaAtacado
{
    public abstract class BasePesoCarga : BaseVeiculo
    {
        protected double pesoBruto;

        protected double pesoLiquido;

        protected double pesoTotal;

        public double PesoBruto { get => pesoBruto; set => pesoBruto = value; }
        public double PesoLiquido { get => pesoLiquido; set => pesoLiquido = value; }
        public double PesoTotal { get => pesoTotal; set => pesoTotal = value; }

        public BasePesoCarga() : base()
        { }

        public BasePesoCarga(int codigo, bool ativo, DateTime dataInclusao, string chassi, string cor, string marca, string modelo,
            string placa, double pesoBruto, double pesoLiquido, double pesoTotal)
            : base(codigo, ativo, dataInclusao, chassi, cor, marca, modelo, placa)
        {
            this.pesoBruto = pesoBruto;
            this.pesoLiquido = pesoLiquido;
            this.pesoTotal = pesoTotal;
        }

    }
}
