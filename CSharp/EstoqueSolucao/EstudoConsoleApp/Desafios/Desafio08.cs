using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio08
     {
        public static void Executar()
         {
            Console.WriteLine("Quantos reais voce tem na carteira: ");
            double valor = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Voce pode comprar {0} dolares", valor / 5.0);
         }
     }

}
