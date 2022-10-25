using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dominio.RH
{
    public abstract class BasePessoa
    {
        private int id;
        private Endereco endereco;
        protected int Id { get => id; set => id = value; }
        protected Endereco Endereco { get => endereco; set => endereco = value; }

        public BasePessoa()
        {
            this.endereco = new Endereco();
        }

        protected BasePessoa(int id) : this()
        {
            this.id = id;
        }
    }
}
