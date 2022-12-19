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
    public class AutorPorItemServico : GenericService<AutorPorItem, AutorPorItemPoco>
    {
        public AutorPorItemServico(LibTecContext contexto) : base(contexto)
        { }

        public override List<AutorPorItemPoco> Consultar(Expression<Func<AutorPorItem, bool>>? predicate = null)
        {
            IQueryable<AutorPorItem> query;
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

        public override List<AutorPorItemPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<AutorPorItem> query;
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

        public override List<AutorPorItemPoco> ConverterPara(IQueryable<AutorPorItem> query)
        {
            return query.Select(api =>
                new AutorPorItemPoco()
                {
                    CodigoAutorPorItem = api.CodigoAutorPorItem,
                    CodigoAutor = api.CodigoAutor,
                    CodigoItem = api.CodigoItem,
                    Ativo = api.Ativo,
                    DataInclusao = api.DataInclusao,
                    DataAlteracao = api.DataAlteracao,
                    DataExclusao = api.DataExclusao
                }).ToList();
        }
    }
}