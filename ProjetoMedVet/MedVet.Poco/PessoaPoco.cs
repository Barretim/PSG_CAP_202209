namespace MedVet.Poco
{
    public class PessoaPoco
    {
        public PessoaPoco()
        {
        }

        public int CodigoPessoa { get; set; }

        public int CodigoTipoPessoa { get; set; }

        public string SiglaTipoPessoa { get; set; } = null!;

        public string Nome { get; set; } = null!;

        public int CodigoEndereco { get; set; }

        public string CPF { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public string Sexo { get; set; } = null!;

        public string? Escolaridade { get; set; } = null!;

        public DateTime? DataNascimento { get; set; }

        public string Email { get; set; } = null!;

        public string? Cargo { get; set; } = null!;

        public DateTime? DataAdmissao { get; set; }

        public DateTime? DataDemissao { get; set; }

        public bool Ativo { get; set; }

        public DateTime? DataInsert { get; set; }

        public DateTime? DataUpdate { get; set; }

        public DateTime? DataDelete { get; set; }

    }
}

