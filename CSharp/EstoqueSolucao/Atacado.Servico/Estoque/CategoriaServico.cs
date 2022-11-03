using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.Estoque;
using Atacado.Repositorio.Estoque;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Atacado.Servico.Estoque
{
    public class CategoriaServico : BaseServico<CategoriaPoco, Categoria>
    {
        private CategoriaRepo repo;

        public CategoriaServico() : base()
        {
            this.repo = new CategoriaRepo();
        }

        public override CategoriaPoco Add(CategoriaPoco poco)
        {
            Categoria nova = this.ConvertTo(poco);
            Categoria criada = this.repo.Create(nova);
            CategoriaPoco criadaPoco = this.ConvertTo(criada);
            return criadaPoco;

        }

        public override List<CategoriaPoco> Browse()
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
            //List<CategoriaPoco> listaPoco = this.repo.Read()
            //    .Select(cat => new CategoriaPoco()
            //    {
            //        Codigo = cat.Codigo,
            //        Descricao = cat.Descricao,
            //        Ativo = cat.Ativo,
            //        DataInsert = cat.DataInsert
            //    }
            //    )
            //    .ToList();
            //return listaPoco;

            return this.Browse(null);
        }
        
        //Adicionado apos o fim:----------------------------------------------------------------------------
        public override List<CategoriaPoco> Browse(Expression<Func<Categoria, bool>> predicado = null)
        {
            List<CategoriaPoco> listaPoco;
            IQueryable<Categoria> query;
            if (predicado == null)
            {
                query = this.repo.Read(null);
            }
            else
            {
                query = this.repo.Read(predicado);
            }
            listaPoco = query.Select(cat => new CategoriaPoco()
            {
                Codigo = cat.Codigo,
                Descricao = cat.Descricao,
                Ativo = cat.Ativo,
                DataInsert = cat.DataInsert
            }
            ).ToList();
            return listaPoco;
        }
        //-----------------------------------------------------------------------------------------------------

        public override CategoriaPoco ConvertTo(Categoria dominio)
        {
            return new CategoriaPoco()
            {
                Codigo = dominio.Codigo,
                Descricao = dominio.Descricao,
                Ativo = dominio.Ativo,
                DataInsert = dominio.DataInsert
            };
        }

        public override Categoria ConvertTo(CategoriaPoco poco)
        {
            return new Categoria()
            {
                Codigo = poco.Codigo,
                Descricao = poco.Descricao,
                Ativo = poco.Ativo,
                DataInsert = poco.DataInsert
            };
        }

        public override CategoriaPoco Delete(int chave)
        {
            Categoria del = this.repo.Delete(chave);
            CategoriaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override CategoriaPoco Delete(CategoriaPoco poco)
        {

            //outra forma:
            //Categoria del = this.repo.Delete(ConvertTo(poco));
            //CategoriaPoco delPoco = this.ConvertTo(del);
            //return delPoco;
            Categoria del = this.repo.Delete(poco.Codigo);
            CategoriaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override CategoriaPoco Edit(CategoriaPoco poco)
        {
            Categoria editada = this.ConvertTo(poco);
            Categoria alterada = this.repo.Create(editada);
            CategoriaPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override CategoriaPoco Read(int chave)
        {
            Categoria lida = this.repo.Read(chave);
            CategoriaPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
