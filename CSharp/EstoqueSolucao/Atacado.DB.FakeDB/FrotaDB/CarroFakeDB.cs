using Atacado.Dominio.FrotaAtacado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaDB
{
    public static class CarroFakeDB
    {
        private static List<Carro> carros;
        public static List<Carro> Carros
        {
            get
            {
                if (carros == null)
                {
                    carros = new List<Carro>();
                    Carregar();
                }
                return carros;
            }
        }
        private static void Carregar()
        {
            carros.Add(new Carro(1, true, DateTime.Now, "4n4b44fk1j34f1019", "Preto", "Volkswagen", "Gol", "FEF-8422", 20.000, 19.000, 39.000, 5));
            carros.Add(new Carro(2, true, DateTime.Now, "2C2C22ytcP79e0692", "Branca", "Hyundai", "IX35", "JTH-2214", 35.000, 34.000, 69.000, 5));
            carros.Add(new Carro(3, true, DateTime.Now, "24C2CyLmDj4507919", "Cinza", "Volkswagen", "Amarok", "CED-2145", 70.000, 80.000, 150.000, 5));
            carros.Add(new Carro(4, true, DateTime.Now, "5D8S5XD1D7A507738", "Preto", "Hyundai", "HB20", "UTB-9962", 35.000, 34.000, 69.000, 5));
            carros.Add(new Carro(5, true, DateTime.Now, "9DD1D2D1D2a7C1508", "Cinza", "Volkswagen", "Polo", "BWD-7145", 38.000, 37.000, 69.000, 5));
        }
    }
}
