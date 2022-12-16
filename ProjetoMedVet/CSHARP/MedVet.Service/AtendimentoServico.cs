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
    public class AtendimentoServico : GenericService<Atendimento, AtendimentoPoco>
    {
        public AtendimentoServico(MedVetContext context) : base(context)
        { }

        public override List<AtendimentoPoco> Consultar(Expression<Func<Atendimento, bool>>? predicate = null)
        {
            IQueryable<Atendimento> query;
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

        public override List<AtendimentoPoco> Listar(int? take, int? skip = null)
        {
            IQueryable<Atendimento> query;
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

        public override List<AtendimentoPoco> ConverterPara(IQueryable<Atendimento> query)
        {
            return query.Select(ate => new AtendimentoPoco
            {
                CodigoAtendimento = ate.CodigoAtendimento,
                CodigoTipoAtendimento = ate.CodigoTipoAtendimento,
                SiglaTipoAtendimento = ate.SiglaTipoAtendimento,
                CodigoAtendente = ate.CodigoAtendente,
                CodigoPaciente = ate.CodigoPaciente,
                CodigoMedico = ate.CodigoMedico,
                CodigoConvenio = ate.CodigoConvenio,
                Descricao = ate.Descricao,
                DataHora = ate.DataHora,
                Ativo = ate.Ativo,
                DataInsert = ate.DataInsert,
                DataUpdate = ate.DataUpdate,
                DataDelete = ate.DataDelete
            }).ToList();
        }
    }
}
