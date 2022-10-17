using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio10
    {
        public static void Executar()
        {
            Console.WriteLine("Informe o preço do produto: ");
            double preco = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Novo valor com 5% de desconto: {0} ", (preco - (preco * 0.05)));
        }
    }
}
