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
    public class PessoaServico : GenericService<Pessoa, PessoaPoco>
    {
        public PessoaServico(MedVetContext context) : base(context)
        { }

        public override List<PessoaPoco> Consultar(Expression<Func<Pessoa, bool>>? predicate = null)
        {
            IQueryable<Pessoa> query;
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

        public override List<PessoaPoco> Listar(int? take, int? skip = null)
        {
            IQueryable<Pessoa> query;
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

        public override List<PessoaPoco> ConverterPara(IQueryable<Pessoa> query)
        {
            return query.Select(pes => new PessoaPoco
            {
                CodigoPessoa = pes.CodigoPessoa,
                CodigoTipoPessoa = pes.CodigoTipoPessoa,
                SiglaTipoPessoa = pes.SiglaTipoPessoa,
                Nome = pes.Nome,
                CodigoEndereco = pes.CodigoEndereco,
                CPF = pes.CPF,
                Telefone = pes.Telefone,
                Sexo = pes.Sexo,
                Escolaridade = pes.Escolaridade,
                DataNascimento = pes.DataNascimento,
                Email = pes.Email,
                Cargo = pes.Cargo,
                DataAdmissao = pes.DataAdmissao,
                DataDemissao = pes.DataDemissao,
                Ativo = pes.Ativo,
                DataInsert = pes.DataInsert,
                DataUpdate = pes.DataUpdate,
                DataDelete = pes.DataDelete
            }).ToList();
        }
    }
}