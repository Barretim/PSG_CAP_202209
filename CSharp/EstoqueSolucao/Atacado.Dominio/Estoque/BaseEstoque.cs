using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dominio.Estoque
{
    public abstract class BaseEstoque
    {
        protected int codigo;
        protected string descricao;
        protected bool ativo;
        protected DateTime dataInclusao;


        public int Codigo { get => codigo; set => codigo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public bool Ativo { get => ativo; set => ativo = value; }
        public DateTime DataInclusao { get => dataInclusao; set => dataInclusao = value; }

        public BaseEstoque()
        {
        }

        public BaseEstoque(int codigo, string descricao, bool ativo, DateTime dataInclusao)
        {
            this.codigo = codigo;
            this.descricao = descricao;
            this.ativo = ativo;
            this.dataInclusao = dataInclusao;
        }

    }
}


