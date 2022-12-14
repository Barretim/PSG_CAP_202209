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
    public class pontoparadaservice : GenericService<pontoparada, pontoparadapoco>
    {
        public pontoparadaservice(ViajeFacilContexto context) : base(context)
        { }

        public override List<pontoparadapoco> Consultar(Expression<Func<pontoparada, bool>>? predicate = null)
        {
            IQueryable<pontoparada> query;
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

        public override List<pontoparadapoco> Listar(int? take, int? skip = null)
        {
            IQueryable<pontoparada> query;
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

        public override List<pontoparadapoco> ConverterPara(IQueryable<pontoparada> query)
        {
            return query.Select(pon => new pontoparadapoco
            {
                codigopontoparada = pon.codigopontoparada,
                descricao = pon.descricao,
                latitude = pon.latitude,
                longitude = pon.longitude,
                codigorota = pon.codigorota
            }).ToList();
        }
    }
}
