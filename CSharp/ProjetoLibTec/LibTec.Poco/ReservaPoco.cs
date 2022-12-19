namespace LibTec.Poco
{
    public class ReservaPoco
    {
        public ReservaPoco()
        {
        }

        public int CodigoReserva { get; set; }

        public int CodigoUsuario { get; set; }

        public int CodigoItem { get; set; }

        public int CodigoStatus { get; set; }

        public bool? Ativo { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }
    }
}
