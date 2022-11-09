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
    public class SubcategoriaServico : BaseServico<SubcategoriaPoco, Subcategoria>
    {
        //private SubcategoriaRepo repo;

        private GenericRepository<Subcategoria> genrepo;

        public SubcategoriaServico() : base()
        {
            //this.repo = new SubcategoriaRepo();

            this.genrepo = new GenericRepository<Subcategoria>();
        }

        public override SubcategoriaPoco Add(SubcategoriaPoco poco)
        {
            Subcategoria nova = this.ConvertTo(poco);
            //Subcategoria criada = this.repo.Create(nova);
            Subcategoria criada = this.genrepo.Insert(nova);
            SubcategoriaPoco criadaPoco = this.ConvertTo(criada);
            return criadaPoco;

        }

        public override List<SubcategoriaPoco> Browse()
        {
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
            //List<SubcategoriaPoco> listaPoco = this.repo.Read()
            //    .Select(cat => new SubcategoriaPoco()
            //    {
            //        Codigo = cat.Codigo,
            //        CodigoCategoria = cat.CodigoCategoria,
            //        Descricao = cat.Descricao,
            //        Ativo = cat.Ativo,
            //        DataInsert = cat.DataInsert

            //    }
            //    )
            //    .ToList();
            //return listaPoco;

            return this.Browse(null);
        }

        //Adicionado apos o fim:------------------------------------------------------------------------------
        public override List<SubcategoriaPoco> Browse(Expression<Func<Subcategoria, bool>> predicado = null)
        {
            List<SubcategoriaPoco> listaPoco;
            IQueryable<Subcategoria> query;
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
            listaPoco = query.Select(cat => new SubcategoriaPoco()
            {
                Codigo = cat.Codigo,
                CodigoCategoria = cat.CodigoCategoria,
                Descricao = cat.Descricao,
                Ativo = cat.Ativo,
                DataInsert = cat.DataInsert
            }
            ).ToList();
            return listaPoco;
        }
        //------------------------------------------------------------------------------------------------------

        public override SubcategoriaPoco ConvertTo(Subcategoria dominio)
        {
            return new SubcategoriaPoco()
            {
                Codigo = dominio.Codigo,
                CodigoCategoria = dominio.CodigoCategoria,
                Descricao = dominio.Descricao,
                Ativo = dominio.Ativo,
                DataInsert = dominio.DataInsert

            };
        }

        public override Subcategoria ConvertTo(SubcategoriaPoco poco)
        {
            return new Subcategoria()
            {
                Codigo = poco.Codigo,
                CodigoCategoria = poco.CodigoCategoria,
                Descricao = poco.Descricao,
                Ativo = poco.Ativo,
                DataInsert = poco.DataInsert

            };
        }

        public override SubcategoriaPoco Delete(int chave)
        {
            //Subcategoria del = this.repo.Delete(chave);
            Subcategoria del = this.genrepo.Delete(chave);
            SubcategoriaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override SubcategoriaPoco Delete(SubcategoriaPoco poco)
        {

            //outra forma:
            //Categoria del = this.repo.Delete(ConvertTo(poco));
            //CategoriaPoco delPoco = this.ConvertTo(del);
            //return delPoco;
            //---------------------------------------------------
            //Subcategoria del = this.repo.Delete(poco.Codigo);
            Subcategoria del = this.genrepo.Delete(poco.Codigo);
            SubcategoriaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override SubcategoriaPoco Edit(SubcategoriaPoco poco)
        {
            Subcategoria editada = this.ConvertTo(poco);
            //Subcategoria alterada = this.repo.Create(editada);
            Subcategoria alterada = this.genrepo.Update(editada);
            SubcategoriaPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override SubcategoriaPoco Read(int chave)
        {
            //Subcategoria lida = this.repo.Read(chave);
            Subcategoria lida = this.genrepo.GetById(chave);
            SubcategoriaPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}