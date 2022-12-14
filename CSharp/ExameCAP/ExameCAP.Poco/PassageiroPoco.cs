namespace ExameCAP.Poco
{
    public partial class PassageiroPoco
    {
        public PassageiroPoco()
        {
        }

        public int CodigoPassageiro { get; set; }

        public string Documento { get; set; } = null!;

        public string NumeroCartao { get; set; } = null!;

        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public string Usuario { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public DateTime? DataNascimento { get; set; }


    }
}
