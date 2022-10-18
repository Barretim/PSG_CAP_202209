using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio13
    {
        public static void Executar()
        {
            Console.WriteLine("Por quantos dias o carro foi alugado? ");
            double dia = Convert.ToDouble(Console.ReadLine());
            double diapagar = dia * 60;
            Console.WriteLine("Quantos km foram rodados? ");
            double kilometro = Convert.ToDouble(Console.ReadLine());
            double kilometropagar = kilometro * 0.15;
            Console.WriteLine("O total a pagar deve ser R${0}", diapagar * kilometropagar);
        }
    }
}
