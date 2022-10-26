using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.Estoque
{
    public class SubcategoriaPoco : BaseEstoque
    {

        private int codigoCategoria;

        public int CodigoCategoria { get => codigoCategoria; set => codigoCategoria = value; }

        public SubcategoriaPoco(int codigoCategoria) : base()
        {
        }

        public SubcategoriaPoco(int codigo, string descricao, bool ativo, DateTime dataInclusao, int codigoCategoria)
            : base(codigo, descricao, ativo, dataInclusao)
        {
            this.codigoCategoria = codigoCategoria;
        }


    }
}
