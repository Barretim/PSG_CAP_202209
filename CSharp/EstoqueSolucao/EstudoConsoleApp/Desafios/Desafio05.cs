using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio05
    {
        public static void Executar()
        {
            Console.WriteLine("Informe a primeira nota: ");
            double n1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Informe a segunda nota: ");
            double n2 = Convert.ToDouble(Console.ReadLine());

            double media = (n1 + n2) / 2;

            Console.WriteLine("A media é: {0}", media);
        }
    }
}
