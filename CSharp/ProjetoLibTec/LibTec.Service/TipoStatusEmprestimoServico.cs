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
    public class TipoStatusEmprestimoServico : GenericService<TipoStatusEmprestimo, TipoStatusEmprestimoPoco>
    {
        public TipoStatusEmprestimoServico(LibTecContext contexto) : base(contexto)
        { }

        public override List<TipoStatusEmprestimoPoco> Consultar(Expression<Func<TipoStatusEmprestimo, bool>>? predicate = null)
        {
            IQueryable<TipoStatusEmprestimo> query;
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

        public override List<TipoStatusEmprestimoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoStatusEmprestimo> query;
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

        public override List<TipoStatusEmprestimoPoco> ConverterPara(IQueryable<TipoStatusEmprestimo> query)
        {
            return query.Select(tse =>
                new TipoStatusEmprestimoPoco()
                {
                    CodigoTipoStatusEmprestimo = tse.CodigoTipoStatusEmprestimo,
                    Descricao = tse.Descricao,
                    Ativo = tse.Ativo,
                    DataInclusao = tse.DataInclusao,
                    DataAlteracao = tse.DataAlteracao,
                    DataExclusao = tse.DataExclusao
                }).ToList();
        }
    }
}