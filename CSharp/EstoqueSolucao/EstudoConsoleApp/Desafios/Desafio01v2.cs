using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio01v2
    {
        public static void Executar()
        {
            string nome;
            Console.WriteLine("Digite seu nome: ");
            nome = Console.ReadLine();
            if (nome == string.Empty)
            {
                Console.WriteLine("por favor digite um nome.");
                return;
            }
            else if (Regex.IsMatch(nome,"[a-z]+$") == false)
            {
                Console.WriteLine("Digite apenas letras.");
                return;
            }

            Console.WriteLine("Seja bem vindo, {0}.", nome);
        }
    }
}
