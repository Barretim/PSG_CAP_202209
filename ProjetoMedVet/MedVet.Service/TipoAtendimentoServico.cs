using MedVet.Domain.EF;
using MedVet.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedVet.Service
{
    public class TipoAtendimentoServico : GenericService<TipoAtendimento, TipoAtendimentoPoco>
    {
        public TipoAtendimentoServico(MedVetContext context) : base(context)
        { }

        public override List<TipoAtendimentoPoco> Consultar(Expression<Func<TipoAtendimento, bool>>? predicate = null)
        {
            IQueryable<TipoAtendimento> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            return this.ConverterPara(query);
        }

        public override List<TipoAtendimentoPoco> Listar(int? take, int? skip = null)
        {
            IQueryable<TipoAtendimento> query;
            if (skip == null)
            {
                query = this.genrepo.GetAll();
            }
            else
            {
                query = this.genrepo.GetAll(take, skip);
            }
            return this.ConverterPara(query);
        }

        public override List<TipoAtendimentoPoco> ConverterPara(IQueryable<TipoAtendimento> query)
        {
            return query.Select(tat => new TipoAtendimentoPoco
            {
                CodigoTipoAtendimento = tat.CodigoTipoAtendimento,
                Sigla = tat.Sigla,
                Descricao = tat.Descricao,
                Ativo = tat.Ativo,
                DataInsert = tat.DataInsert,
                DataUpdate = tat.DataUpdate,
                DataDelete = tat.DataDelete
            }).ToList();
        }
    }
}