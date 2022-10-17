using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio02
    {
        public static void Executar()
        {
            Console.WriteLine("informe o dia: ");
            int dia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("informe o mês: ");
            int mes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("informe o ano: ");
            int ano = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            DateTime data = new DateTime(ano, mes, dia);
            Console.WriteLine("A data informada foi: ");
            Console.WriteLine(data.ToString("MM/dd/yyyy"));

        }

    }
}
