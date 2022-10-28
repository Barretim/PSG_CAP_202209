using Atacado.DB.FakeDB.Estoque;
using Atacado.DB.FakeDB.FrotaDB;
using Atacado.Dominio.Estoque;
using Atacado.Dominio.FrotaAtacado;
using Atacado.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repositorio.RepFrota
{
    public class CarroRepositorio : BaseRepositorio<Carro>
    {
        private FrotaContexto contexto;

        public CarroRepositorio()
        {
            this.contexto = new FrotaContexto();
        }

        public override Carro Create(Carro instancia)
        {
            return this.contexto.AddCarro(instancia);
        }

        public override Carro Delete(int chave)
        {
            Carro del = this.Read(chave);
            if (this.contexto.Carros.Remove(del) == false)
            {
                return null;
            }
            else
            {
                return del;
            }
        }

        public override Carro Delete(Carro instancia)
        {
            return this.Delete(instancia.Codigo);
        }

        public override Carro Read(int chave)
        {
            return this.contexto.Carros.SingleOrDefault(cat => cat.Codigo == chave);
        }

        public override List<Carro> Read()
        {
            return this.contexto.Carros;
        }

        public override Carro Update(Carro instancia)
        {
            Carro atu = this.Read(instancia.Codigo);
            if (atu == null)
            {
                return null;
            }
            else
            {
                atu.Ativo = instancia.Ativo;
                atu.DataInclusao = instancia.DataInclusao;
                atu.Chassi = instancia.Chassi;
                atu.Cor = instancia.Cor;
                atu.Marca = instancia.Marca;
                atu.Modelo = instancia.Modelo;
                atu.Placa = instancia.Placa;
                atu.PesoBruto = instancia.PesoBruto;
                atu.PesoLiquido = instancia.PesoLiquido;
                atu.PesoTotal = instancia.PesoTotal;
                atu.NumPassageiros = instancia.NumPassageiros;
                return atu;
            }
        }
    }
}
