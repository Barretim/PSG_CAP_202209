using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio11
    {
        public static void Executar()
        {
            Console.WriteLine("Informe o salário: ");
            double salario = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Novo sálario com 15% de aumento: {0} ", (salario + (salario * 0.15)));
        }
    }
}
