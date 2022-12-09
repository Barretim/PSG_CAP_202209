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
    public class instituicaoservice : GenericService<instituicao, instituicaopoco>
    {
        public instituicaoservice(ViajeFacilContexto context) : base(context)
        { }

        public override List<instituicaopoco> Consultar(Expression<Func<instituicao, bool>>? predicate = null)
        {
            IQueryable<instituicao> query;
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

        public override List<instituicaopoco> Listar(int? take, int? skip = null)
        {
            IQueryable<instituicao> query;
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

        public override List<instituicaopoco> ConverterPara(IQueryable<instituicao> query)
        {
            return query.Select(ins => new instituicaopoco
            {
                codigoinstituicao = ins.codigoinstituicao,
                nome = ins.nome,
                telefone = ins.telefone,
                codigoendereco = ins.codigoendereco
            }).ToList();
        }
    }
}
