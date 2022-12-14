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
    public class paisservice : GenericService<pais, paispoco>
    {
        public paisservice(ViajeFacilContexto context) : base(context)
        { }

        public override List<paispoco> Consultar(Expression<Func<pais, bool>>? predicate = null)
        {
            IQueryable<pais> query;
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

        public override List<paispoco> Listar(int? take, int? skip = null)
        {
            IQueryable<pais> query;
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

        public override List<paispoco> ConverterPara(IQueryable<pais> query)
        {
            return query.Select(pai => new paispoco
            {
                codigopais = pai.codigopais,
                nome = pai.nome
            }).ToList();
        }
    }
}
