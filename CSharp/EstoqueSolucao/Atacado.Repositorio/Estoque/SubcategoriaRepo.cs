using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Repositorio.Base;
using Atacado.Dominio.Estoque;
using Atacado.DB.FakeDB.Estoque;

namespace Atacado.Repositorio.Estoque
{
    public class SubcategoriaRepo : BaseRepositorio<Subcategoria>
    {
        private EstoqueContexto contexto;

        public SubcategoriaRepo()
        {
            this.contexto = new EstoqueContexto();
        }

        public override Subcategoria Create(Subcategoria instancia)
        {
            return this.contexto.AddSubcategoria(instancia);
        }

        public override Subcategoria Delete(int chave)
        {
            Subcategoria del = this.Read(chave);
            if (this.contexto.Subcategorias.Remove(del) == false)
            {
                return null;
            }
            else
            {
                return del;
            }
        }

        public override Subcategoria Delete(Subcategoria instancia)
        {
            return this.Delete(instancia.Codigo);
        }

        public override Subcategoria Read(int chave)
        {
            return this.contexto.Subcategorias.SingleOrDefault(cat => cat.Codigo == chave);
        }

        public override List<Subcategoria> Read()
        {
            return this.contexto.Subcategorias;
        }

        public override Subcategoria Update(Subcategoria instancia)
        {
            Subcategoria atu = this.Read(instancia.Codigo);
            if (atu == null)
            {
                return null;
            }
            else
            {
                atu.Descricao = instancia.Descricao;
                atu.Ativo = instancia.Ativo;
                return atu;
            }
        }
    }
}
