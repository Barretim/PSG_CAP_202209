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
    public class SubcategoriaServico : BaseServico<SubcategoriaPoco, Subcategoria>
    {
        private SubcategoriaRepo repo;

        public SubcategoriaServico() : base()
        {
            this.repo = new SubcategoriaRepo();
        }

        public override SubcategoriaPoco Add(SubcategoriaPoco poco)
        {
            Subcategoria nova = this.ConvertTo(poco);
            Subcategoria criada = this.repo.Create(nova);
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
            List<SubcategoriaPoco> listaPoco = this.repo.Read()
                .Select(cat => new SubcategoriaPoco()
                {
                    Codigo = cat.Codigo,
                    Descricao = cat.Descricao,
                    DataInsert = cat.DataInsert,
                    CodigoCategoria = cat.CodigoCategoria
                }
                )
                .ToList();
            return listaPoco;
        }

        public override SubcategoriaPoco ConvertTo(Subcategoria dominio)
        {
            return new SubcategoriaPoco()
            {
                Codigo = dominio.Codigo,
                Descricao = dominio.Descricao,
                DataInsert = dominio.DataInsert,
                CodigoCategoria = dominio.CodigoCategoria
            };
        }

        public override Subcategoria ConvertTo(SubcategoriaPoco poco)
        {
            return new Subcategoria()
            {
                Codigo = poco.Codigo,
                Descricao = poco.Descricao,
                DataInsert = poco.DataInsert,
                CodigoCategoria = poco.CodigoCategoria
            };
        }

        public override SubcategoriaPoco Delete(int chave)
        {
            Subcategoria del = this.repo.Delete(chave);
            SubcategoriaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override SubcategoriaPoco Delete(SubcategoriaPoco poco)
        {

            //outra forma:
            //Categoria del = this.repo.Delete(ConvertTo(poco));
            //CategoriaPoco delPoco = this.ConvertTo(del);
            //return delPoco;
            Subcategoria del = this.repo.Delete(poco.Codigo);
            SubcategoriaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override SubcategoriaPoco Edit(SubcategoriaPoco poco)
        {
            Subcategoria editada = this.ConvertTo(poco);
            Subcategoria alterada = this.repo.Create(editada);
            SubcategoriaPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override SubcategoriaPoco Read(int chave)
        {
            Subcategoria lida = this.repo.Read(chave);
            SubcategoriaPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}