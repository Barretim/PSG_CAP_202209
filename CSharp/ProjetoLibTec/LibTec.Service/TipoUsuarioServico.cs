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
    public class TipoUsuarioServico : GenericService<TipoUsuario, TipoUsuarioPoco>
    {
        public TipoUsuarioServico(LibTecContext contexto) : base(contexto)
        { }

        public override List<TipoUsuarioPoco> Consultar(Expression<Func<TipoUsuario, bool>>? predicate = null)
        {
            IQueryable<TipoUsuario> query;
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

        public override List<TipoUsuarioPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoUsuario> query;
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

        public override List<TipoUsuarioPoco> ConverterPara(IQueryable<TipoUsuario> query)
        {
            return query.Select(tis =>
                new TipoUsuarioPoco()
                {
                    CodigoTipoUsuario = tis.CodigoTipoUsuario,
                    Descricao = tis.Descricao,
                    Ativo = tis.Ativo,
                    DataInclusao = tis.DataInclusao,
                    DataAlteracao = tis.DataAlteracao,
                    DataExclusao = tis.DataExclusao
                }).ToList();
        }
    }
}