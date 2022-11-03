using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Repositorio.Base;
using Atacado.DB.EF.Database;
using System.Linq.Expressions;

namespace Atacado.Repositorio.Estoque
{
    public class ProdutoRepo : BaseRepositorio<Produto>
    {
        private ProjetoAcademiaContext contexto;

        public ProdutoRepo()
        {
            this.contexto = new ProjetoAcademiaContext();
        }

        public override Produto Create(Produto instancia)
        {
            this.contexto.Produtos.Add(instancia);
            return instancia;
        }

        public override Produto Delete(int chave)
        {
            Produto del = this.Read(chave);
            if (del == null)
            {
                return null;
            }
            else
            {
                this.contexto.Produtos.Remove(del);
                return del;
            }
        }

        public override Produto Delete(Produto instancia)
        {
            return this.Delete(instancia.Codigo);
        }

        public override Produto Read(int chave)
        {
            return this.contexto.Produtos.SingleOrDefault(cat => cat.Codigo == chave);
        }

        public override List<Produto> Read()
        {
            return this.contexto.Produtos.ToList();
        }

        //Adicionando apos o fim:--------------------------------------------------------------------------------------------
        public override IQueryable<Produto> Read(Expression<Func<Produto, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return this.contexto.Produtos.AsQueryable();
            }
            else
            {
                return this.contexto.Produtos.Where(predicate).AsQueryable();
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------

        public override Produto Update(Produto instancia)
        {
            Produto atu = this.Read(instancia.Codigo);
            if (atu == null)
            {
                return null;
            }
            else
            {
                atu.CodigoCategoria = instancia.CodigoCategoria;
                atu.CodigoSubcategoria = instancia.CodigoSubcategoria;
                atu.Descricao = instancia.Descricao;
                return atu;
            }
        }
    }
}
