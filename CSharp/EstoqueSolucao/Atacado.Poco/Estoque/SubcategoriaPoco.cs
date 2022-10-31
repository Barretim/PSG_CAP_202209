using System;

namespace Atacado.Poco.Estoque
{

    public  class SubcategoriaPoco
    {
        public SubcategoriaPoco()
        { }

        public int Codigo { get; set; }

        public int CodigoCategoria { get; set; }

        public string Descricao { get; set; } = null!;

        public DateTime DataInsert { get; set; }
    }
}
