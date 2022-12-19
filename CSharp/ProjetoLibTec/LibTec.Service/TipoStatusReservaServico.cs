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
    public class TipoStatusReservaServico : GenericService<TipoStatusReserva, TipoStatusReservaPoco>
    {
        public TipoStatusReservaServico(LibTecContext contexto) : base(contexto)
        { }

        public override List<TipoStatusReservaPoco> Consultar(Expression<Func<TipoStatusReserva, bool>>? predicate = null)
        {
            IQueryable<TipoStatusReserva> query;
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

        public override List<TipoStatusReservaPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoStatusReserva> query;
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

        public override List<TipoStatusReservaPoco> ConverterPara(IQueryable<TipoStatusReserva> query)
        {
            return query.Select(tir =>
                new TipoStatusReservaPoco()
                {
                    CodigoTipoStatusReserva = tir.CodigoTipoStatusReserva,
                    Descricao = tir.Descricao,
                    Ativo = tir.Ativo,
                    DataInclusao = tir.DataInclusao,
                    DataAlteracao = tir.DataAlteracao,
                    DataExclusao = tir.DataExclusao
                }).ToList();
        }
    }
}