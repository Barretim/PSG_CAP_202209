using LibTec.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibTec.Domain.EF;
using LibTec.Poco;
using System.Linq.Expressions;

namespace LibTec.Service
{
    public class EmprestimoServico : GenericService<Emprestimo, EmprestimoPoco>
    {
        public EmprestimoServico(LibTecContext contexto) : base(contexto)
        { }

        public override List<EmprestimoPoco> Consultar(Expression<Func<Emprestimo, bool>>? predicate = null)
        {
            IQueryable<Emprestimo> query;
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

        public override List<EmprestimoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Emprestimo> query;
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

        public override List<EmprestimoPoco> ConverterPara(IQueryable<Emprestimo> query)
        {
            return query.Select(emp =>
                new EmprestimoPoco()
                {
                    CodigoEmprestimo = emp.CodigoEmprestimo,
                    CodigoUsuario = emp.CodigoUsuario,
                    CodigoItem = emp.CodigoItem,
                    CodigoQtdRenovado = emp.CodigoQtdRenovado,
                    DataSaida = emp.DataSaida,
                    DataExpiracao = emp.DataExpiracao,
                    DataRetorno = emp.DataRetorno,
                    CodigoStatus = emp.CodigoStatus,
                    Ativo = emp.Ativo,
                    DataInclusao = emp.DataInclusao,
                    DataAlteracao = emp.DataAlteracao,
                    DataExclusao = emp.DataExclusao
                }).ToList();
        }
    }
}