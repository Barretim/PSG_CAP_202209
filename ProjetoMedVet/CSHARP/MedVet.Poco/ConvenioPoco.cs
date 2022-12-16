namespace MedVet.Poco
{
    public class ConvenioPoco
    {
        public ConvenioPoco()
        {
        }

        public int CodigoConvenio { get; set; }

       public string Descricao { get; set; } = null!;

        public string Plano { get; set; } = null!;

        public decimal Tarifa { get; set; }

    }
}
