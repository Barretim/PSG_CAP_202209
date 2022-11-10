using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.Estoque;
using System.Linq.Expressions;
using Atacado.Repositorio.Base;

namespace Atacado.Servico.Estoque
{
    public class ProdutoServico : GenericService<Produto,ProdutoPoco>
    {
        public override ProdutoPoco ConverterPara(Produto obj)
        {
            return new ProdutoPoco()
            {
                Codigo = obj.Codigo,
                CodigoCategoria = obj.CodigoCategoria,
                CodigoSubcategoria = obj.CodigoSubcategoria,
                Descricao = obj.Descricao,
                Ativo = obj.Ativo,
                DataInsert = obj.DataInsert
            };
        }

        public override Produto ConverterPara(ProdutoPoco obj)
        {
            return new Produto()
            {
                Codigo = obj.Codigo,
                CodigoCategoria = obj.CodigoCategoria,
                CodigoSubcategoria = obj.CodigoSubcategoria,
                Descricao = obj.Descricao,
                Ativo = obj.Ativo,
                DataInsert = obj.DataInsert
            };
        }

        public override List<ProdutoPoco> Consultar(Expression<Func<Produto, bool>>? predicate = null)
        {
            IQueryable<Produto> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            return ConverterPara(query);
        }

        public override List<ProdutoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Produto> query;
            if (skip == null)
            {
                query = this.genrepo.GetAll();
            }
            else
            {
                query = this.genrepo.GetAll(take, skip);
            }
            return ConverterPara(query);
        }

        public override List<ProdutoPoco> ConverterPara(IQueryable<Produto> query)
        {
            return query.Select(prd => new ProdutoPoco()
            {
                Codigo = prd.Codigo,
                CodigoCategoria = prd.CodigoCategoria,
                CodigoSubcategoria = prd.CodigoSubcategoria,
                Descricao = prd.Descricao,
                Ativo = prd.Ativo,
                DataInsert = prd.DataInsert
            }
            ).ToList();
        }
    }
}