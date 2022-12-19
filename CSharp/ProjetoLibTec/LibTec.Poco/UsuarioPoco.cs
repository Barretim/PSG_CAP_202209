namespace LibTec.Poco
{
    public  class UsuarioPoco
    {
        public UsuarioPoco()
        {
        }

        public int CodigoUsuario { get; set; }

        public string Nome { get; set; } = null!;

        public string Sobrenome { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int MaxEmprestimos { get; set; }

        public int CodigoTipoUsuario { get; set; }

        public bool? Ativo { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }
    }
}
