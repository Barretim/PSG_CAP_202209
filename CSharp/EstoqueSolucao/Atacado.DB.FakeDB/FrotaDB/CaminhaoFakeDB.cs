using Atacado.Dominio.FrotaAtacado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaDB
{
    public static class CaminhaoFakeDB
    {
        private static List<Caminhao> caminhoes;
        public static List<Caminhao> Caminhoes
        {
            get
            {
                if (caminhoes == null)
                {
                    caminhoes = new List<Caminhao>();
                    Carregar();
                }
                return caminhoes;
            }
        }
        private static void Carregar()
        {
            caminhoes.Add(new Caminhao(1, true, DateTime.Now, "78343AmFL50va2030", "Preto", "Volvo", "Fh 550", "KGC-6601", 987.000, 124.325, 112.000));
            caminhoes.Add(new Caminhao(2, true, DateTime.Now, "378gPrYWlP46Y0267", "Preto", "Mercedes", "Accelo", "UEG-3408", 955.000, 245.357, 332.114));
            caminhoes.Add(new Caminhao(3, true, DateTime.Now, "73q833c9Aal5s5526", "Preto", "Volvo", "Fh 550", "NBW-9751", 224.000, 354.987, 998.004));
            caminhoes.Add(new Caminhao(4, true, DateTime.Now, "8625AR9z820e66931", "Preto", "Mercedes", "Accelo", "VER-6481", 997.000, 576.214, 332.001));
            caminhoes.Add(new Caminhao(5, true, DateTime.Now, "5v24blK1fx5V50064", "Preto", "Volvo", "Fh 550", "MQT-8363", 330.666, 994.657, 987.332));
        }
    }
}
