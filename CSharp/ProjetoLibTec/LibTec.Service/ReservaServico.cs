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
    public class ReservaServico : GenericService<Reserva, ReservaPoco>
    {
        public ReservaServico(LibTecContext contexto) : base(contexto)
        { }

        public override List<ReservaPoco> Consultar(Expression<Func<Reserva, bool>>? predicate = null)
        {
            IQueryable<Reserva> query;
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

        public override List<ReservaPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Reserva> query;
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

        public override List<ReservaPoco> ConverterPara(IQueryable<Reserva> query)
        {
            return query.Select(res =>
                new ReservaPoco()
                {
                    CodigoReserva = res.CodigoReserva,
                    CodigoUsuario = res.CodigoUsuario,
                    CodigoItem = res.CodigoItem,
                    CodigoStatus = res.CodigoStatus,
                    Ativo = res.Ativo,
                    DataInclusao = res.DataInclusao,
                    DataAlteracao = res.DataAlteracao,
                    DataExclusao = res.DataExclusao
                }).ToList();
        }
    }
}