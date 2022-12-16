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
    public class ConvenioServico : GenericService<Convenio, ConvenioPoco>
    {
        public ConvenioServico(MedVetContext context) : base(context)
        { }

        public override List<ConvenioPoco> Consultar(Expression<Func<Convenio, bool>>? predicate = null)
        {
            IQueryable<Convenio> query;
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

        public override List<ConvenioPoco> Listar(int? take, int? skip = null)
        {
            IQueryable<Convenio> query;
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

        public override List<ConvenioPoco> ConverterPara(IQueryable<Convenio> query)
        {
            return query.Select(con => new ConvenioPoco
            {
                CodigoConvenio = con.CodigoConvenio,
                Descricao = con.Descricao,
                Plano = con.Plano,
                Tarifa = con.Tarifa
            }).ToList();
        }
    }
}