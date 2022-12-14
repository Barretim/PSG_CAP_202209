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
    public class eventoservice : GenericService<evento, eventopoco>
    {
        public eventoservice(ViajeFacilContexto context) : base(context)
        { }

        public override List<eventopoco> Consultar(Expression<Func<evento, bool>>? predicate = null)
        {
            IQueryable<evento> query;
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

        public override List<eventopoco> Listar(int? take, int? skip = null)
        {
            IQueryable<evento> query;
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

        public override List<eventopoco> ConverterPara(IQueryable<evento> query)
        {
            return query.Select(eve => new eventopoco
            {
                codigoevento = eve.codigoevento,
                titulo = eve.titulo,
                descricao = eve.descricao,
                dataida = eve.dataida,
                datavolta = eve.datavolta,
                codigoinstituicao = eve.codigoinstituicao,
                codigorotaida = eve.codigorotaida,
                codigorotavolta = eve.codigorotavolta,
                codigousuarioresponsavel = eve.codigousuarioresponsavel
            }).ToList();
        }
    }
}
