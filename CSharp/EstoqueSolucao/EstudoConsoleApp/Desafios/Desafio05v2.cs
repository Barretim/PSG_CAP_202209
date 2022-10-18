using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio05v2
    {
        public static void Executar()
        {
            double n1, n2;
            Console.WriteLine("Informe a primeira nota: ");
            if (Double.TryParse(Console.ReadLine(), out n1) == false)
            {
                Console.WriteLine("por favor informe uma nota valida.");
                return;
            }

            Console.WriteLine("Informe a segunda nota: ");
            if (Double.TryParse(Console.ReadLine(), out n2) == false)
            {
                Console.WriteLine("por favor informe uma nota valida.");
                return;
            }

            double media = (n1 + n2) / 2;

            Console.WriteLine("A media é: {0}", media);
        }
    }
}
