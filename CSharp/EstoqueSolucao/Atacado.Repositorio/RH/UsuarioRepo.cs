using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Dominio.RH;
using Atacado.DB.FakeDB.RH;
using Atacado.Repositorio.Base;
using Atacado.DB.FakeDB.Estoque;

namespace Atacado.Repositorio.RH
{
    public class UsuarioRepo : BaseRepositorio<Usuario>
    {
        private RHContexto contexto;

        public UsuarioRepo()
        {
            this.contexto = new RHContexto();
        }

        public override Usuario Create(Usuario instancia)
        {
            return this.contexto.AddUsuario(instancia);
        }

        public override Usuario Delete(int chave)
        {
            Usuario del = this.Read(chave);
            if (this.contexto.Usuarios.Remove(del) == false)
            {
                return null;
            }
            else
            {
                return del;
            }
        }

        public override Usuario Delete(Usuario instancia)
        {
            return this.Delete(instancia.Id);
        }

        public override Usuario Read(int chave)
        {
            return this.contexto.Usuarios.SingleOrDefault(usu => usu.Id == chave);
        }

        public override List<Usuario> Read()
        {
           return this.contexto.Usuarios;
        }

        public override Usuario Update(Usuario instancia)
        {
            Usuario atu = this.Read(instancia.Id);
            if (atu == null)
            {
                return null;
            }
            else
            {
                atu.Login = instancia.Login;
                atu.Senha = instancia.Senha;
                atu.Permissao = instancia.Permissao;
                return atu;
            }
        }
    }
}
