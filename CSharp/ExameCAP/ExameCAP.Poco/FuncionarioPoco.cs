namespace ExameCAP.Poco
{
    public partial class FuncionarioPoco
    {
        public FuncionarioPoco()
        {
        }

        public int CodigoPassageiro { get; set; }

        public string Matricula { get; set; } = null!;

        public string ContaCorrente { get; set; } = null!;

        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public string Usuario { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public DateTime? DataNascimento { get; set; }

    }
}
