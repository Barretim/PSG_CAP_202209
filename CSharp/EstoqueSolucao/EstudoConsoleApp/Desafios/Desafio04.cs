using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio04
    {
        public static void Executar()
        {
            Console.WriteLine("Informe o numero");
            int num = Convert.ToInt32(Console.ReadLine());
            int dobro = num * 2;
            int triplo = num * 3;
            double raiz = Math.Sqrt(Convert.ToDouble(num));
            Console.WriteLine("para o numero {0}", num);
            Console.WriteLine("o dobro do valor é: {0}", dobro);
            Console.WriteLine("o triplo do valor é: {0}", triplo);
            Console.WriteLine("a raiz do valor é: {0}", raiz);
        }
    }
}
