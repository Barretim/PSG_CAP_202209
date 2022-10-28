using Atacado.Dominio.FrotaAtacado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaDB
{
    public static class FrotaFakeDB
    {
        private static List<Frota> frotas;
        public static List<Frota> Frotas
        {
            get
            {
                if (frotas == null)
                {
                    frotas = new List<Frota>();
                    Carregar();
                }
                return frotas;
            }
        }
        private static void Carregar()
        {
            frotas.Add(new Frota(1, true, DateTime.Now, "Boiadeiro", 5));
            frotas.Add(new Frota(2, true, DateTime.Now, "Boiadeiro", 13));
            frotas.Add(new Frota(3, true, DateTime.Now, "Boiadeiro", 55));
            frotas.Add(new Frota(4, true, DateTime.Now, "Boiadeiro", 41));
            frotas.Add(new Frota(5, true, DateTime.Now, "Boiadeiro", 61));
        }
    }
}
