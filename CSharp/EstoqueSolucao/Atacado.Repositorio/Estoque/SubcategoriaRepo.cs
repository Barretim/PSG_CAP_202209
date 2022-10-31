using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Repositorio.Base;
using Atacado.DB.EF.Database;

namespace Atacado.Repositorio.Estoque
{
    public class SubcategoriaRepo : BaseRepositorio<Subcategoria>
    {
        private ProjetoAcademiaContext contexto;

        public SubcategoriaRepo()
        {
            this.contexto = new ProjetoAcademiaContext();
        }

        public override Subcategoria Create(Subcategoria instancia)
        {
            this.contexto.Subcategorias.Add(instancia);
            return instancia;
        }

        public override Subcategoria Delete(int chave)
        {
            Subcategoria del = this.Read(chave);
            if (del == null)
            {
                return null;
            }
            else
            {
                this.contexto.Subcategorias.Remove(del);
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
            return this.contexto.Subcategorias.ToList();
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
                atu.CodigoCategoria = instancia.CodigoCategoria;
                atu.Descricao = instancia.Descricao;
                return atu;
            }
        }
    }
}
