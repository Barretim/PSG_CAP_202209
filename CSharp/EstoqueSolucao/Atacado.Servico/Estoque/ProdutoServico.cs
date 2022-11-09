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
    public class ProdutoServico : BaseServico<ProdutoPoco, Produto>
    {
        //private ProdutoRepo repo;

        private GenericRepository<Produto> genrepo;

        public ProdutoServico() : base()
        {
           // this.repo = new ProdutoRepo();

            this.genrepo = new GenericRepository<Produto>(); 
        }

        public override ProdutoPoco Add(ProdutoPoco poco)
        {
            Produto nova = this.ConvertTo(poco);
            //Produto criada = this.repo.Create(nova);
            Produto criada = this.genrepo.Insert(nova);
            ProdutoPoco criadaPoco = this.ConvertTo(criada);
            return criadaPoco;

        }

        public override List<ProdutoPoco> Browse()
        {
            return this.Browse(null);


            //Modo 1:
            //List<Categoria> lista = this.repo.Read();
            //List<CategoriaPoco> listaPoco = new List<CategoriaPoco>();
            //foreach (Categoria item in lista)
            //{
            //    CategoriaPoco poco = this.ConvertTo(item);
            //    listaPoco.Add(poco);
            //}
            //return listaPoco;


            //Modo 2:
            //List<CategoriaPoco> listaPoco = this.repo.Read().Select(cat => new CategoriaPoco(cat.Codigo, cat.Descricao, cat.Ativo, cat.DataInclusao)).ToList();
            //return listaPoco;


            //Modo 3:
            //List<ProdutoPoco> listaPoco = this.repo.Read()
            //    .Select(cat => new ProdutoPoco()
            //    {
            //        Codigo = cat.Codigo,
            //        CodigoCategoria = cat.CodigoCategoria,
            //        CodigoSubcategoria = cat.CodigoSubcategoria,
            //        Descricao = cat.Descricao,
            //        Ativo = cat.Ativo,
            //        DataInsert = cat.DataInsert

            //    }
            //    )
            //    .ToList();
            //return listaPoco;


        }

        //Adicionado apos o fim:----------------------------------------------------------------------------
        public override List<ProdutoPoco> Browse(Expression<Func<Produto, bool>> predicado = null)
        {
            List<ProdutoPoco> listaPoco;
            IQueryable<Produto> query;
            if (predicado == null)
            {
                //query = this.repo.Read(null);
                query = this.genrepo.Browseable(null);
            }
            else
            {
                //query = this.repo.Read(predicado);
                query = this.genrepo.Browseable(predicado);
            }
            listaPoco = query.Select(cat => new ProdutoPoco()
            {
                Codigo = cat.Codigo,
                CodigoCategoria = cat.CodigoCategoria,
                CodigoSubcategoria = cat.CodigoSubcategoria,
                Descricao = cat.Descricao,
                Ativo = cat.Ativo,
                DataInsert = cat.DataInsert
            }
            ).ToList();
            return listaPoco;
        }
        //----------------------------------------------------------------------------------------------------
        public override ProdutoPoco ConvertTo(Produto dominio)
        {
            return new ProdutoPoco()
            {
                Codigo = dominio.Codigo,
                CodigoCategoria = dominio.CodigoCategoria,
                CodigoSubcategoria = dominio.CodigoSubcategoria,
                Descricao = dominio.Descricao,
                Ativo = dominio.Ativo,
                DataInsert = dominio.DataInsert
                
            };
        }

        public override Produto ConvertTo(ProdutoPoco poco)
        {
            return new Produto()
            {
                Codigo = poco.Codigo,
                CodigoCategoria = poco.CodigoCategoria,
                CodigoSubcategoria = poco.CodigoSubcategoria,
                Descricao = poco.Descricao,
                Ativo = poco.Ativo,
                DataInsert = poco.DataInsert
                
            };
        }

        public override ProdutoPoco Delete(int chave)
        {
            //Produto del = this.repo.Delete(chave);
            Produto del = this.genrepo.Delete(chave);
            ProdutoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ProdutoPoco Delete(ProdutoPoco poco)
        {

            //outra forma:
            //Categoria del = this.repo.Delete(ConvertTo(poco));
            //CategoriaPoco delPoco = this.ConvertTo(del);
            //return delPoco;
            //-------------------------------------------------
            //Produto del = this.repo.Delete(poco.Codigo);
            Produto del = this.genrepo.Delete(poco.Codigo);
            ProdutoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ProdutoPoco Edit(ProdutoPoco poco)
        {
            Produto editada = this.ConvertTo(poco);
            //Produto alterada = this.repo.Create(editada);
            Produto alterada = this.genrepo.Update(editada);
            ProdutoPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override ProdutoPoco Read(int chave)
        {
            //Produto lida = this.repo.Read(chave);
            Produto lida = this.genrepo.GetById(chave);
            ProdutoPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}