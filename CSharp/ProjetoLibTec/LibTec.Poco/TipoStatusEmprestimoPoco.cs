namespace LibTec.Poco
{
    public class TipoStatusEmprestimoPoco
    {
        public TipoStatusEmprestimoPoco()
        {
        }

        public int CodigoTipoStatusEmprestimo { get; set; }

        public string Descricao { get; set; } = null!;

        public bool? Ativo { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

    }
}
