using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio14
    {
        public static void Executar()
        {
            List<string> nomes = new List<string>();
            bool fim = false;
            while (fim == false)
            { 
                Console.WriteLine("Nomes na lista: {0}", nomes.Count);
                bool testar = true;
                while (testar == true)
                {
                    Console.Write("Insira um nome: ");
                    string nome = Console.ReadLine();
                    if (string.IsNullOrEmpty(nome.Trim()) == true )
                    {
                        Console.WriteLine("É obrigatório inserir um nome.");
                        Console.WriteLine("Tente novamente");
                        testar = true;
                    }
                    else
                    { 
                        nomes.Add(nome);
                        fim = false;
                    }
                }
                Console.WriteLine("Deseja sair? <S/N>:");
                string teste = Console.ReadLine();
                if (teste.ToUpper() == "S")
                {
                    fim = true;
                }
                else
                {
                    Console.Clear();
                    fim = false;
                }
            }
            Console.Clear();
            Console.WriteLine("Imprimindo nomes na lista:");
            foreach (string nome in nomes)
            {
                Console.WriteLine("\t Nome: {0}", nome);
            }
        }
    }
}
