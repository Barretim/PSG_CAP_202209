using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Dominio.RH;

namespace Atacado.DB.FakeDB.RH
{
    public static class UsuarioFakeDB
    {
        private static List<Usuario> usuarios;

        public static List<Usuario> Usuarios
        {
            get
            {
                if (usuarios == null)
                {
                    usuarios = new List<Usuario>();
                    Carregar();
                }
                return usuarios;
            }
        }

        public static void Carregar()
        {
            usuarios.Add(new Usuario());
            usuarios.Add(new Usuario());
            usuarios.Add(new Usuario());
            usuarios.Add(new Usuario());
            usuarios.Add(new Usuario());
        }

    }
}