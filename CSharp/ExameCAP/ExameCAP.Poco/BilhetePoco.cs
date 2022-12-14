namespace ExameCAP.Poco
{
    public partial class BilhetePoco
    {
        public BilhetePoco()
        {
        }

        public int CodigoBilhete { get; set; }

        public int NumeroBilhete { get; set; }

        public string Assento { get; set; } = null!;


    }
}
