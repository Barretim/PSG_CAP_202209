using Atacado.Dominio.FrotaAtacado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaDB
{
    public static class MotocicletaFakeDB
    {
        private static List<Motocicleta> motocicletas;
        public static List<Motocicleta> Motocicletas
        {
            get
            {
                if (motocicletas == null)
                {
                    motocicletas = new List<Motocicleta>();
                    Carregar();
                }
                return motocicletas;
            }
        }
        private static void Carregar()
        {
            motocicletas.Add(new Motocicleta(1, true, DateTime.Now, "34Fr3b3mNu9AC7554", "Preto", "Kawazaki", "Ninja 300", "NRG-5686", 258, 174, 174));
            motocicletas.Add(new Motocicleta(2, true, DateTime.Now, "35FMJW903M9kd7362", "Branca", "Kawazaki", "Ninja 600", "BRF-8838", 369, 386, 685));
            motocicletas.Add(new Motocicleta(3, true, DateTime.Now, "B232B33gS0TxS8866", "Preto", "Kawazaki", "Ninja 800", "PIB-8883", 177, 275, 285));
            motocicletas.Add(new Motocicleta(4, true, DateTime.Now, "3H5B53PbJ9Rzn7635", "Branca", "Kawazaki", "Ninja 1000", "CET-1714", 285, 887, 174));
            motocicletas.Add(new Motocicleta(5, true, DateTime.Now, "1F3FF1F30j91M6968", "Vermelha", "Kawazaki", "Ninja 600", "NHT-8688", 385, 385, 963));
        }
    }
}
