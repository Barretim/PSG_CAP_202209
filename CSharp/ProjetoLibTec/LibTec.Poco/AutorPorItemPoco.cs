namespace LibTec.Poco
{
    public class AutorPorItemPoco
    {
        public AutorPorItemPoco()
        {
        }

        public int CodigoAutorPorItem { get; set; }

        public int CodigoAutor { get; set; }

        public int CodigoItem { get; set; }

        public bool? Ativo { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

    }
}
