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
    public class CidadeServico : GenericService<Cidade, CidadePoco>
    {
        public CidadeServico(MedVetContext context) : base(context)
        { }

        public override List<CidadePoco> Consultar(Expression<Func<Cidade, bool>>? predicate = null)
        {
            IQueryable<Cidade> query;
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

        public override List<CidadePoco> Listar(int? take, int? skip = null)
        {
            IQueryable<Cidade> query;
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

        public override List<CidadePoco> ConverterPara(IQueryable<Cidade> query)
        {
            return query.Select(cid => new CidadePoco
            {
                CodigoCidade = cid.CodigoCidade,
                Nome = cid.Nome,
                CodigoIBGE7 = cid.CodigoIBGE7,
                CodigoEstado = cid.CodigoEstado,
            }).ToList();
        }
    }
}