using EstudoConsoleApp.Aulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio03
    {
        public static void Executar()
        {
            Console.WriteLine("Informe o primeiro numero");
            int n1 = int.Parse(Console.ReadLine());

            Console.WriteLine("informe o segundo numero");
            int n2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Somar: {0}", OperacoesMatematicas.Somar(n1, n2));
            Console.WriteLine();
        }
    }
}
