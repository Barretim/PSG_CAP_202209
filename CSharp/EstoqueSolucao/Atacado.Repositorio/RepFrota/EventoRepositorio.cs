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
    public class EventoRepositorio : BaseRepositorio<EventoFrota>
    {
        private FrotaContexto contexto;

        public EventoRepositorio()
        {
            this.contexto = new FrotaContexto();
        }

        public override EventoFrota Create(EventoFrota instancia)
        {
            return this.contexto.AddEventoFrota(instancia);
        }

        public override EventoFrota Delete(int chave)
        {
            EventoFrota del = this.Read(chave);
            if (this.contexto.EventoFrotas.Remove(del) == false)
            {
                return null;
            }
            else
            {
                return del;
            }
        }

        public override EventoFrota Delete(EventoFrota instancia)
        {
            return this.Delete(instancia.Codigo);
        }

        public override EventoFrota Read(int chave)
        {
            return this.contexto.EventoFrotas.SingleOrDefault(cat => cat.Codigo == chave);
        }

        public override List<EventoFrota> Read()
        {
            return this.contexto.EventoFrotas;
        }

        public override EventoFrota Update(EventoFrota instancia)
        {
            EventoFrota atu = this.Read(instancia.Codigo);
            if (atu == null)
            {
                return null;
            }
            else
            {
                atu.Ativo = instancia.Ativo;
                atu.DataInclusao = instancia.DataInclusao;
                atu.Condutor = instancia.Condutor;
                atu.DataInicial = instancia.DataInicial;
                atu.DataFinal = instancia.DataFinal;
                atu.KmInicial = instancia.KmInicial;
                atu.KmFinal = instancia.KmFinal;
                atu.MotivoEvento = instancia.MotivoEvento;
                return atu;
            }
        }
    }
}
