using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.Base
{
    public interface IGenericService<TDominio, TPoco>
        where TDominio : class
        where TPoco : class
    {
        List<TPoco> Listar();

        IQueryable<TPoco> Consultar(Expression<Func<TDominio, bool>> predicate = null);

        TPoco PesquisaPelaChave(object chave);

        TPoco Inserir(TPoco obj);

        TPoco Alterar(TPoco obj);

        TPoco Excluir(object chave);

        TDominio ConverterPara(TPoco obj);

        TPoco ConverterPara(TDominio obj);
    }
}
