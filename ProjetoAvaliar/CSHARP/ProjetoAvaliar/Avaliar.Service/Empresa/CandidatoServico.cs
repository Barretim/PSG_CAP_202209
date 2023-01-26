using Avaliar.Domain.EF;
using Avaliar.Poco;
using Avaliar.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Service.Empresa
{
    public class CandidatoServico : GenericServico<Candidato, CandidatoPoco>
    {
        public CandidatoServico(AvaliarContext contexto) : base(contexto)
        { }

        public override List<CandidatoPoco> Consultar(Expression<Func<Candidato, bool>>? predicate = null)
        {
            IQueryable<Candidato> query;
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

        public override List<CandidatoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Candidato> query;
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

        public override List<CandidatoPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<Candidato, bool>>? predicate = null)
        {
            IQueryable<Candidato> query;
            if (skip == null)
            {
                if (predicate == null)
                {
                    query = this.genrepo.Browseable(null);
                }
                else
                {
                    query = this.genrepo.Browseable(predicate);
                }
            }
            else
            {
                if (predicate == null)
                {
                    query = this.genrepo.GetAll(take, skip);
                }
                else
                {
                    query = this.genrepo.Searchable(take, skip, predicate);
                }
            }
            return this.ConverterPara(query);
        }

        public override List<CandidatoPoco> ConverterPara(IQueryable<Candidato> query)
        {
            return query.Select(can =>
                new CandidatoPoco()
                {
                    CodigoCandidato = can.CodigoCandidato,
                    CodigoProfissao = can.CodigoProfissao,
                    Nome = can.Nome,
                    Sobrenome = can.Sobrenome,
                    Email = can.Email,
                    Situacao = can.Situacao,
                    DataInclusao = can.DataInclusao,
                }).ToList();
        }

        public override int ContarTotalRegistros(Expression<Func<Candidato, bool>>? predicate)
        {
            IQueryable<Candidato> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            return query.Count();
        }
    }
}
