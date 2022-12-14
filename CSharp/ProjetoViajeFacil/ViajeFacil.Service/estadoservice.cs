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
    public class estadoservice : GenericService<estado, estadopoco>
    {
        public estadoservice(ViajeFacilContexto context) : base(context)
        { }

        public override List<estadopoco> Consultar(Expression<Func<estado, bool>>? predicate = null)
        {
            IQueryable<estado> query;
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

        public override List<estadopoco> Listar(int? take, int? skip = null)
        {
            IQueryable<estado> query;
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

        public override List<estadopoco> ConverterPara(IQueryable<estado> query)
        {
            return query.Select(est => new estadopoco
            {
                codigoestado = est.codigoestado,
                nome = est.nome,
                uf = est.uf,
                codigoregiao = est.codigoregiao,
                codigouf = est.codigouf
            }).ToList();
        }
    }
}
