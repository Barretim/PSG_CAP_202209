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
    public class CaminhaoRepositorio : BaseRepositorio<Caminhao>
    {
        private FrotaContexto contexto;

        public CaminhaoRepositorio()
        {
            this.contexto = new FrotaContexto();
        }

        public override Caminhao Create(Caminhao instancia)
        {
            return this.contexto.AddCaminhao(instancia);
        }

        public override Caminhao Delete(int chave)
        {
            Caminhao del = this.Read(chave);
            if (this.contexto.Caminhoes.Remove(del) == false)
            {
                return null;
            }
            else
            {
                return del;
            }
        }

        public override Caminhao Delete(Caminhao instancia)
        {
            return this.Delete(instancia.Codigo);
        }

        public override Caminhao Read(int chave)
        {
            return this.contexto.Caminhoes.SingleOrDefault(cat => cat.Codigo == chave);
        }

        public override List<Caminhao> Read()
        {
            return this.contexto.Caminhoes;
        }

        public override Caminhao Update(Caminhao instancia)
        {
            Caminhao atu = this.Read(instancia.Codigo);
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
                return atu;
            }
        }
    }
}
