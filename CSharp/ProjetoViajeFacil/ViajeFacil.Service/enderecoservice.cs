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
    public class enderecoserveice : GenericService<endereco, enderecopoco>
    {
        public enderecoserveice(ViajeFacilContexto context) : base(context)
        { }

        public override List<enderecopoco> Consultar(Expression<Func<endereco, bool>>? predicate = null)
        {
            IQueryable<endereco> query;
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

        public override List<enderecopoco> Listar(int? take, int? skip = null)
        {
            IQueryable<endereco> query;
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

        public override List<enderecopoco> ConverterPara(IQueryable<endereco> query)
        {
            return query.Select(end => new enderecopoco
            {
                codigoendereco = end.codigoendereco,
                rua = end.rua,
                numero = end.numero,
                complemento = end.complemento,
                bairro = end.bairro,
                cep = end.cep,
                codigocidade = end.codigocidade
            }).ToList();
        }
    }
}
