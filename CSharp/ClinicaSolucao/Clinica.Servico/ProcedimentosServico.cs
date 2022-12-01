using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica.Servico;
using Clinica.Dominio.EF;
using Clinica.Poco;
using System.Linq.Expressions;

namespace Clinica.Servico
{
    public class ProcedimentosServico : GenericServico<Clinica.Dominio.EF.Servico, ServicoPoco>
    {

        public ProcedimentosServico(ClinicaContext contexto) : base(contexto)
        { }

        public override List<ServicoPoco> Consultar(Expression<Func<Clinica.Dominio.EF.Servico, bool>>? predicate = null)
        {
            IQueryable<Clinica.Dominio.EF.Servico> query;
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

        public override List<ServicoPoco> Listar(int? take, int? skip = null)
        {
            IQueryable<Clinica.Dominio.EF.Servico> query;
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

        public override List<ServicoPoco> Vasculhar(int? take, int? skip = null, Expression<Func<Dominio.EF.Servico, bool>>? predicate = null)
        {
            IQueryable<Clinica.Dominio.EF.Servico> query;
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

        public override List<ServicoPoco> ConverterPara(IQueryable<Clinica.Dominio.EF.Servico> query)
        {
            return query.Select(pro => new ServicoPoco()
            {
                CodigoServico = pro.CodigoServico,
                Descricao = pro.Descricao,
                Preco = pro.Preco,
                TipoServico = pro.TipoServico,
                Situacao = pro.Situacao,
                DataInclusao = pro.DataInclusao,
                DataAlteracao = pro.DataAlteracao,
                MedidaPreventiva = pro.MedidaPreventiva,
                TipoExame = pro.TipoExame,
                MaterialUsado = pro.MaterialUsado,
                DenteTratado = pro.DenteTratado,
                DenteExtraido = pro.DenteExtraido,
                DenteCanalPar = pro.DenteExtraido,
                CodigoTipoServico = pro.CodigoTipoServico
            }).ToList();
        }
    }
}

