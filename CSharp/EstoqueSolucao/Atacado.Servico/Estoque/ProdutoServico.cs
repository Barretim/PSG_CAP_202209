using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.Estoque;
using Atacado.Repositorio.Estoque;

namespace Atacado.Servico.Estoque
{
    public class ProdutoServico : BaseServico<ProdutoPoco, Produto>
    {
        private ProdutoRepo repo;

        public ProdutoServico() : base()
        {
            this.repo = new ProdutoRepo();
        }

        public override ProdutoPoco Add(ProdutoPoco poco)
        {
            Produto nova = this.ConvertTo(poco);
            Produto criada = this.repo.Create(nova);
            ProdutoPoco criadaPoco = this.ConvertTo(criada);
            return criadaPoco;

        }

        public override List<ProdutoPoco> Browse()
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
            List<ProdutoPoco> listaPoco = this.repo.Read()
                .Select(cat => new ProdutoPoco()
                {
                    Codigo = cat.Codigo,
                    Descricao = cat.Descricao,
                    DataInsert = cat.DataInsert,
                    CodigoSubcategoria = cat.CodigoSubcategoria
                }
                )
                .ToList();
            return listaPoco;
        }

        public override ProdutoPoco ConvertTo(Produto dominio)
        {
            return new ProdutoPoco()
            {
                Codigo = dominio.Codigo,
                Descricao = dominio.Descricao,
                DataInsert = dominio.DataInsert,
                CodigoSubcategoria = dominio.CodigoSubcategoria
            };
        }

        public override Produto ConvertTo(ProdutoPoco poco)
        {
            return new Produto()
            {
                Codigo = poco.Codigo,
                Descricao = poco.Descricao,
                DataInsert = poco.DataInsert,
                CodigoSubcategoria = poco.CodigoSubcategoria
            };
        }

        public override ProdutoPoco Delete(int chave)
        {
            Produto del = this.repo.Delete(chave);
            ProdutoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ProdutoPoco Delete(ProdutoPoco poco)
        {

            //outra forma:
            //Categoria del = this.repo.Delete(ConvertTo(poco));
            //CategoriaPoco delPoco = this.ConvertTo(del);
            //return delPoco;
            Produto del = this.repo.Delete(poco.Codigo);
            ProdutoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ProdutoPoco Edit(ProdutoPoco poco)
        {
            Produto editada = this.ConvertTo(poco);
            Produto alterada = this.repo.Create(editada);
            ProdutoPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override ProdutoPoco Read(int chave)
        {
            Produto lida = this.repo.Read(chave);
            ProdutoPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}