using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dominio.RH
{
    public class Usuario
    {
        private int id;
        private string login;
        private string senha;
        private string permissao;
        private Parceiro colaborador;


        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Permissao { get => permissao; set => permissao = value; }
        public Parceiro Colaborador { get => colaborador; set => colaborador = value; }
        

        public Usuario()
        {
        }

        public Usuario(int id, string login, string senha, string permissao)
        {
            this.id = id;
            this.login = login;
            this.senha = senha;
            this.permissao = permissao;
        }
    }
}
