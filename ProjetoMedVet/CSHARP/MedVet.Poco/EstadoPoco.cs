namespace MedVet.Poco
{
    public class EstadoPoco
    {
        public EstadoPoco()
        {
        }

        public long CodigoEstado { get; set; }
        public string Nome { get; set; } = null!;
        public string UF { get; set; } = null!;
    }
}