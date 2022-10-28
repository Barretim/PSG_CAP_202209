using Atacado.Dominio.FrotaAtacado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaDB
{
    public class EventoFrotaFakeDB
    {
        private static List<EventoFrota> eventoFrotas;
        public static List<EventoFrota> EventoFrotas
        {
            get
            {
                if (eventoFrotas == null)
                {
                    eventoFrotas = new List<EventoFrota>();
                    Carregar();
                }
                return eventoFrotas;
            }
        }
        private static void Carregar()
        {
            eventoFrotas.Add(new EventoFrota(1, true, DateTime.Now, "Bruno", new DateOnly(2001, 12, 17), new DateOnly(2001, 12, 17), 22122, 9611085, "Boiadeiro"));
            eventoFrotas.Add(new EventoFrota(2, true, DateTime.Now, "Marcelo", new DateOnly(1977, 10, 21), new DateOnly(1977, 10, 21), 99826, 987053, "Boiadeiro"));
            eventoFrotas.Add(new EventoFrota(3, true, DateTime.Now, "Carla", new DateOnly(1960, 11, 11), new DateOnly(1960, 11, 11), 32482, 320560, "Boiadeiro"));
            eventoFrotas.Add(new EventoFrota(4, true, DateTime.Now, "Gabriel", new DateOnly(2007, 12, 12), new DateOnly(2007, 12, 12), 66378, 987986, "Boiadeiro"));
            eventoFrotas.Add(new EventoFrota(5, true, DateTime.Now, "Paula", new DateOnly(2002, 3, 28), new DateOnly(2002, 3, 28), 22052, 987154, "Boiadeiro"));
        }
    }
}
