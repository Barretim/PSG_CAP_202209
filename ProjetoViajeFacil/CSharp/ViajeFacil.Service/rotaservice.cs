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
    public class rotaservice : GenericService<rota, rotapoco>
    {
        public rotaservice(ViajeFacilContexto context) : base(context)
        { }

        public override List<rotapoco> Consultar(Expression<Func<rota, bool>>? predicate = null)
        {
            IQueryable<rota> query;
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

        public override List<rotapoco> Listar(int? take, int? skip = null)
        {
            IQueryable<rota> query;
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

        public override List<rotapoco> ConverterPara(IQueryable<rota> query)
        {
            return query.Select(rot => new rotapoco
            {
                codigorota = rot.codigorota,
                pontoinicial = rot.pontoinicial,
                pontofinal = rot.pontofinal
            }).ToList();
        }
    }
}
