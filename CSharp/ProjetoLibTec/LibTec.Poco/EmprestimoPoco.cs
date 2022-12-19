namespace LibTec.Poco
{
    public class EmprestimoPoco
    {
        public EmprestimoPoco()
        {
        }

        public int CodigoEmprestimo { get; set; }

        public int CodigoUsuario { get; set; }

        public int CodigoItem { get; set; }

        public int? CodigoQtdRenovado { get; set; }

        public DateTime DataSaida { get; set; }

        public DateTime DataExpiracao { get; set; }

        public DateTime DataRetorno { get; set; }

        public int? CodigoStatus { get; set; }

        public bool? Ativo { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }
    }
}
