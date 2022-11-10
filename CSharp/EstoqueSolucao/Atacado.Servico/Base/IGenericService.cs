using Atacado.DB.EF.Database;
using Atacado.Poco.Estoque;
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

        List<TPoco> Listar(int? take, int? skip = null);

        List<TPoco> Consultar(Expression<Func<TDominio, bool>>? predicate = null);

        TPoco? PesquisaPelaChave(object chave);
             
        TPoco? Inserir(TPoco obj);
             
        TPoco? Alterar(TPoco obj);
             
        TPoco? Excluir(object chave);

        TDominio ConverterPara(TPoco obj);

        TPoco ConverterPara(TDominio obj);

        List<ProdutoPoco> ConverterPara(IQueryable<Produto> query);
    }
}
