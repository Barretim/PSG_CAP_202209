namespace LibTec.Poco
{
    public class TipoUsuarioPoco
    {
        public TipoUsuarioPoco()
        {
        }

        public int CodigoTipoUsuario { get; set; }

        public string Descricao { get; set; } = null!;

        public bool? Ativo { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

    }
}
