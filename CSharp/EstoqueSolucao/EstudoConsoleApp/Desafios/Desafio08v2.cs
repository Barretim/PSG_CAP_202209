using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio08v2
     {
        public static void Executar()
         {
            double valor;
            Console.WriteLine("Quantos reais voce tem na carteira: ");
            if (Double.TryParse(Console.ReadLine(), out valor) == false)
            {
                Console.WriteLine("por favor informe um numero valido.");
                return;
            }
            Console.WriteLine("Voce pode comprar {0} dolares", valor / 5.0);
         }
     }

}
