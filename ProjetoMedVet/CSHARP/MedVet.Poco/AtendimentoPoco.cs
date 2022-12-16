namespace MedVet.Poco
{
    public class AtendimentoPoco
    {
        public AtendimentoPoco()
        {
        }

        public int CodigoAtendimento { get; set; }

        public int CodigoTipoAtendimento { get; set; }

        public string SiglaTipoAtendimento { get; set; } = null!;

        public int CodigoAtendente { get; set; }

        public int CodigoPaciente { get; set; }

        public int CodigoMedico { get; set; }

        public int CodigoConvenio { get; set; }

        public string Descricao { get; set; } = null!;

        public DateTime DataHora { get; set; }

        public bool Ativo { get; set; }

        public DateTime? DataInsert { get; set; }

        public DateTime? DataUpdate { get; set; }

        public DateTime? DataDelete { get; set; }
    }
}
