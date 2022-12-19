using LibTec.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibTec.Domain.EF;
using LibTec.Poco;
using System.Linq.Expressions;

namespace LibTec.Service
{
    public class TipoItemServico : GenericService<TipoItem, TipoItemPoco>
    {
        public TipoItemServico(LibTecContext contexto) : base(contexto)
        { }

        public override List<TipoItemPoco> Consultar(Expression<Func<TipoItem, bool>>? predicate = null)
        {
            IQueryable<TipoItem> query;
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

        public override List<TipoItemPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoItem> query;
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

        public override List<TipoItemPoco> ConverterPara(IQueryable<TipoItem> query)
        {
            return query.Select(tis =>
                new TipoItemPoco()
                {
                    CodigoTipoItem = tis.CodigoTipoItem,
                    Descricao = tis.Descricao,
                    Ativo = tis.Ativo,
                    DataInclusao = tis.DataInclusao,
                    DataAlteracao = tis.DataAlteracao,
                    DataExclusao = tis.DataExclusao
                }).ToList();
        }
    }
}