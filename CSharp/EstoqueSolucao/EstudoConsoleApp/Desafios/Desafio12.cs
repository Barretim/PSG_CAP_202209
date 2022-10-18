using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio12
    {
        public static void Executar()
        {
            Console.WriteLine("Informe a tempertara em graus Celsius: ");
            double tempertura = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("A tempertura em Fahrenheit: {0}", (tempertura * 1.8) + 32); 
        }
    }
}
