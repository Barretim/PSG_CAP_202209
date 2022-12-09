using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViajeFacil.Service;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using System.Linq.Expressions;

namespace ViajeFacil.Service
{
    public class cidadeservice : GenericService<cidade, cidadepoco>
    {
        public cidadeservice(ViajeFacilContexto context) : base(context)
        { }

        public override List<cidadepoco> Consultar(Expression<Func<cidade, bool>>? predicate = null)
        {
            IQueryable<cidade> query;
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

        public override List<cidadepoco> Listar(int? take, int? skip = null)
        {
            IQueryable<cidade> query;
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

        public override List<cidadepoco> ConverterPara(IQueryable<cidade> query)
        {
            return query.Select(cid => new cidadepoco
            {
                codigocidade = cid.codigocidade,
                nome = cid.nome,
                codigoibge7 = cid.codigoibge7,
                uf = cid.uf,
                codigoestado = cid.codigoestado
            }).ToList();
        }
    }
}
