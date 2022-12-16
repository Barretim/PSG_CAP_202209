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
    public class TipoPessoaServico : GenericService<TipoPessoa, TipoPessoaPoco>
    {
        public TipoPessoaServico(MedVetContext context) : base(context)
        { }

        public override List<TipoPessoaPoco> Consultar(Expression<Func<TipoPessoa, bool>>? predicate = null)
        {
            IQueryable<TipoPessoa> query;
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

        public override List<TipoPessoaPoco> Listar(int? take, int? skip = null)
        {
            IQueryable<TipoPessoa> query;
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

        public override List<TipoPessoaPoco> ConverterPara(IQueryable<TipoPessoa> query)
        {
            return query.Select(tps => new TipoPessoaPoco
            {
                CodigoTipoPessoa = tps.CodigoTipoPessoa,
                Sigla = tps.Sigla,
                Descricao = tps.Descricao,
                Ativo = tps.Ativo,
                DataInsert = tps.DataInsert,
                DataUpdate = tps.DataUpdate,
                DataDelete = tps.DataDelete
            }).ToList();
        }
    }
}