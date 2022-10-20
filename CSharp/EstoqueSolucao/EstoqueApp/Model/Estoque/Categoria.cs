using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp.Model.Estoque

{
    public class Categoria : BaseEstoque
    {
        private List <Subcategoria> subcategorias;

        public List<Subcategoria> Subcategorias { get => subcategorias; set => subcategorias = value; }
        public Categoria() : base()
        {
            this.subcategorias = new List<Subcategoria>();
        }

        public Categoria(int codigo, string descricao, bool ativo, DateTime dataInclusao) 
            : base(codigo, descricao, ativo, dataInclusao)
        {
        }

        
    }
}
