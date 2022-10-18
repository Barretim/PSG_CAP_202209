using EstudoConsoleApp.Aulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio03v2
    {
        public static void Executar()
        {
            int n1, n2;
            Console.WriteLine("Informe o primeiro numero:");
            if (Int32.TryParse(Console.ReadLine(), out n1) == false)
            {
                Console.WriteLine("por favor informe um valor.");
                return;
            }
            Console.WriteLine("informe o segundo numero: ");
            if (Int32.TryParse(Console.ReadLine(), out n2) == false)
            {
                Console.WriteLine("por favor informe um valor.");
                return;
            }

            Console.WriteLine("Soma: {0}", OperacoesMatematicas.Somar(n1, n2));
            Console.WriteLine();
        }
    }
}
