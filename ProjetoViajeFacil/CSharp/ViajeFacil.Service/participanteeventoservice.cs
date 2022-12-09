using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;

namespace ViajeFacil.Service
{
    public class participanteeventoservice : GenericService<participanteevento, participanteeventopoco>
    {
        public participanteeventoservice(ViajeFacilContexto context) : base(context)
        { }

        public override List<participanteeventopoco> Consultar(Expression<Func<participanteevento, bool>>? predicate = null)
        {
            IQueryable<participanteevento> query;
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

        public override List<participanteeventopoco> Listar(int? take, int? skip = null)
        {
            IQueryable<participanteevento> query;
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

        public override List<participanteeventopoco> ConverterPara(IQueryable<participanteevento> query)
        {
            return query.Select(par => new participanteeventopoco
            {
                codigoparticipante = par.codigoparticipante,
                pagamento = par.pagamento,
                sugestao = par.sugestao,
                avaliacao = par.avaliacao,
                codigoevento = par.codigoevento,
                codigousuario = par.codigousuario
            }).ToList();
        }
    }
}
