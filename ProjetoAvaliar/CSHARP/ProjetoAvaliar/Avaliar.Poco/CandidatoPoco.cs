namespace Avaliar.Poco
{
    public class CandidatoPoco
    {
        public int CodigoCandidato { get; set; }

        public int CodigoProfissao { get; set; }

        public string Nome { get; set; } = null!;

        public string Sobrenome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool? Situacao { get; set; }

        public DateTime? DataInclusao { get; set; }

        public CandidatoPoco()
        {
        }
    }
}
