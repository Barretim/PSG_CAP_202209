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
    public class FrotaRepositorio : BaseRepositorio<Frota>
    {
        private FrotaContexto contexto;

        public FrotaRepositorio()
        {
            this.contexto = new FrotaContexto();
        }

        public override Frota Create(Frota instancia)
        {
            return this.contexto.AddFrota(instancia);
        }

        public override Frota Delete(int chave)
        {
            Frota del = this.Read(chave);
            if (this.contexto.Frotas.Remove(del) == false)
            {
                return null;
            }
            else
            {
                return del;
            }
        }

        public override Frota Delete(Frota instancia)
        {
            return this.Delete(instancia.Codigo);
        }

        public override Frota Read(int chave)
        {
            return this.contexto.Frotas.SingleOrDefault(cat => cat.Codigo == chave);
        }

        public override List<Frota> Read()
        {
            return this.contexto.Frotas;
        }

        public override Frota Update(Frota instancia)
        {
            Frota atu = this.Read(instancia.Codigo);
            if (atu == null)
            {
                return null;
            }
            else
            {
                atu.Ativo = instancia.Ativo;
                atu.DataInclusao = instancia.DataInclusao;
                atu.Finalidade = instancia.Finalidade;
                atu.Veiculos = instancia.Veiculos;
                return atu;
            }
        }
    }
}
