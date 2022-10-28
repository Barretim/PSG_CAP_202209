using Atacado.Dominio.FrotaAtacado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaDB
{
    public static class UtilitarioFakeDB
    {
        private static List<Utilitario> utilitarios;
        public static List<Utilitario> Utilitarios
        {
            get
            {
                if (utilitarios == null)
                {
                    utilitarios = new List<Utilitario>();
                    Carregar();
                }
                return utilitarios;
            }
        }
        private static void Carregar()
        {
            utilitarios.Add(new Utilitario(1, true, DateTime.Now, "234fd75LAwZ2R6905", "Preto", "Volkswagen", "Amarok", "EFF-5487", 7.000, 4.000, 11.000));
            utilitarios.Add(new Utilitario(2, true, DateTime.Now, "5212dcAK9nwAX7402", "Branca", "Chevrolet", "S10", "CEY-3324", 8.000, 2.000, 10.000)); ;
            utilitarios.Add(new Utilitario(3, true, DateTime.Now, "35d5dFT3dAAH56223", "Preto", "Volkswagen", "Polo", "HTG-9872", 9.000, 2.000, 11.000));
            utilitarios.Add(new Utilitario(4, true, DateTime.Now, "2e2221pRnb15m7622", "Branca", "Chevrolet", "Ranger", "YHB-1257", 5.000, 1.000, 6.000));
            utilitarios.Add(new Utilitario(5, true, DateTime.Now, "8f1f6d58ykAg90643", "Preto", "Mitsubish", "Triton", "XRN-3245", 8.000, 1.000, 9.000));
        }
    }
}
