using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio10v2
    {
        public static void Executar()
        {
            double preco;
            Console.WriteLine("Informe o preço do produto: ");
            if (Double.TryParse(Console.ReadLine(), out preco) == false)
            {
                Console.WriteLine("por favor informe um preço valido.");
                return;
            }
            Console.WriteLine("Novo valor com 5% de desconto: {0} ", (preco - (preco * 0.05)));
        }
    }
}
