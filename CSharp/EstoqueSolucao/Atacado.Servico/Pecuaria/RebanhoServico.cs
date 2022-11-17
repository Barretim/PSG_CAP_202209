using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.Pecuaria;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.Pecuaria
{
    public class RebanhoServico : GenericService<Rebanho, RebanhoPoco>
    {
        public override List<RebanhoPoco> Consultar(Expression<Func<Rebanho, bool>>? predicate = null)
        {
            IQueryable<Rebanho> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            List<RebanhoPoco> listaPoco = query.Select(reb => new RebanhoPoco()
            {
                CodigoRebanho = reb.CodigoRebanho,
                AnoRef = reb.AnoRef,
                CodigoMunicipio = reb.CodigoMunicipio,
                CodigoTipoRebanho = reb.CodigoTipoRebanho,
                TipoDoRebanho = reb.TipoDoRebanho,
                Quantidade = reb.Quantidade,
                Situacao = reb.Situacao,
                DataInclusao = reb.DataInclusao,
                DataAlteracao = reb.DataAlteracao,
                DataExclusao = reb.DataExclusao
            }).ToList();
            return listaPoco;
        }
    }
}

