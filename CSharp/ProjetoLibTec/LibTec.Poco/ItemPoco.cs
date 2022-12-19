namespace LibTec.Poco
{
    public class ItemPoco
    {
        public ItemPoco()
        {
        }

        public int CodigoItem { get; set; }

        public string Descricao { get; set; } = null!;

        public string ISBN { get; set; } = null!;

        public string Observacoes { get; set; } = null!;

        public int CodigoTipoItem { get; set; }

        public bool? Ativo { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }
    }
}
