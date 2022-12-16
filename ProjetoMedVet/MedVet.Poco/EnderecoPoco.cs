namespace MedVet.Poco
{ 
    public class EnderecoPoco
    {
        public long CodigoEndereco { get; set; }

        public string Rua { get; set; } = null!;

        public int Numero { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; } = null!;

        public string CEP { get; set; } = null!;

        public long CodigoCidade { get; set; }
    }
}