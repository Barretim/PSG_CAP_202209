using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio07v2
    {
        public static void Executar()
        {
            double num;
            Console.WriteLine("Informe um numero inteiro: ");
            if (Double.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("por favor informe um numero valido.");
                return;
            }
            Console.WriteLine("{0} x 1 = {1}", num, num * 1);
            Console.WriteLine("{0} x 2 = {1}", num, num * 2);
            Console.WriteLine("{0} x 3 = {1}", num, num * 3);
            Console.WriteLine("{0} x 4 = {1}", num, num * 4);
            Console.WriteLine("{0} x 5 = {1}", num, num * 5);
            Console.WriteLine("{0} x 6 = {1}", num, num * 6);
            Console.WriteLine("{0} x 7 = {1}", num, num * 7);
            Console.WriteLine("{0} x 8 = {1}", num, num * 8);
            Console.WriteLine("{0} x 9 = {1}", num, num * 9);
            Console.WriteLine("{0} x 10 = {1}", num, num * 10);

        }
    }
}

