namespace MedVet.Poco
{
    public class TipoAtendimentoPoco
    {
        public TipoAtendimentoPoco()
        {
        }

        public int CodigoTipoAtendimento { get; set; }

        public string Sigla { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public bool Ativo { get; set; }

        public DateTime? DataInsert { get; set; }

        public DateTime? DataUpdate { get; set; }

        public DateTime? DataDelete { get; set; }
    }
}
