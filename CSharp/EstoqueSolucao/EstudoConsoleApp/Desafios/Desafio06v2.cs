using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio06v2
    {
        public static void Executar()
        {
            double num;
            Console.Write("Informe o número em metros: ");
            if (Double.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("por favor informe um valor valido.");
                return;
            }
            double cent = num * 100;
            double mil = num * 1000;
            Console.WriteLine("{0} metros valem {1} centimetros.", num, cent);
            Console.WriteLine("{0} metros valem {1} milimetros.", num, mil);
        }
    }
}
