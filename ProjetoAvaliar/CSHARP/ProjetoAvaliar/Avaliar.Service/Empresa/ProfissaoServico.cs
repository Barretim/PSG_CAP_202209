﻿using Avaliar.Domain.EF;
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
    public class ProfissaoServico : GenericServico<Profissao, ProfissaoPoco>
    {
        public ProfissaoServico(AvaliarContext contexto) : base(contexto)
        { }

        public override List<ProfissaoPoco> Consultar(Expression<Func<Profissao, bool>>? predicate = null)
        {
            IQueryable<Profissao> query;
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

        public override List<ProfissaoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Profissao> query;
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

        public override List<ProfissaoPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<Profissao, bool>>? predicate = null)
        {
            IQueryable<Profissao> query;
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

        public override List<ProfissaoPoco> ConverterPara(IQueryable<Profissao> query)
        {
            return query.Select(pro =>
                new ProfissaoPoco()
                {
                    CodigoProfissao = pro.CodigoProfissao,
                    Descricao = pro.Descricao,
                    Situacao = pro.Situacao,
                    DataInclusao = pro.DataInclusao,
                }).ToList();
        }

        public override int ContarTotalRegistros(Expression<Func<Profissao, bool>>? predicate)
        {
            IQueryable<Profissao> query;
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