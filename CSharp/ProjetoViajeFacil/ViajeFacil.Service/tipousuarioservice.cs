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
    public class tipousuarioservice : GenericService<tipousuario, tipousuariopoco>
    {
        public tipousuarioservice(ViajeFacilContexto context) : base(context)
        { }

        public override List<tipousuariopoco> Consultar(Expression<Func<tipousuario, bool>>? predicate = null)
        {
            IQueryable<tipousuario> query;
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

        public override List<tipousuariopoco> Listar(int? take, int? skip = null)
        {
            IQueryable<tipousuario> query;
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

        public override List<tipousuariopoco> ConverterPara(IQueryable<tipousuario> query)
        {
            return query.Select(tip => new tipousuariopoco
            {
                codigotipousuario = tip.codigotipousuario,
                descricao = tip.descricao
            }).ToList();
        }
    }
}
