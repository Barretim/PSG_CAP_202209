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
    public class regiaoservice : GenericService<regiao, regiaopoco>
    {
        public regiaoservice(ViajeFacilContexto context) : base(context)
        { }

        public override List<regiaopoco> Consultar(Expression<Func<regiao, bool>>? predicate = null)
        {
            IQueryable<regiao> query;
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

        public override List<regiaopoco> Listar(int? take, int? skip = null)
        {
            IQueryable<regiao> query;
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

        public override List<regiaopoco> ConverterPara(IQueryable<regiao> query)
        {
            return query.Select(reg => new regiaopoco
            {
                codigoregiao = reg.codigoregiao,
                nome = reg.nome,
                codigopais = reg.codigopais,
            }).ToList();
        }
    }
}
