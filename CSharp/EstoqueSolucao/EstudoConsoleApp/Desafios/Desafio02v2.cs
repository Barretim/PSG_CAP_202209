using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio02v2
    {
        public static void Executar()
        {
            int dia, mes, ano;
            Console.WriteLine("informe o dia: ");
            if (Int32.TryParse(Console.ReadLine(), out dia) == false)
            {
                Console.WriteLine("informe um dia valido. ");
                return;
            }
            Console.WriteLine("informe o mês: ");
            if (Int32.TryParse(Console.ReadLine(), out mes) == false)
            {
                Console.WriteLine("informe um mes valido.");
                return;
            }
            Console.WriteLine("informe o ano: ");
            if (Int32.TryParse(Console.ReadLine(), out ano) == false)
            {
                Console.WriteLine("informe um ano valido.");
                return;
            }
            Console.WriteLine();
            DateTime data = new DateTime(ano, mes, dia);
            Console.WriteLine("A data informada foi: ");
            Console.WriteLine(data.ToString("MM/dd/yyyy"));

        }

    }
}
