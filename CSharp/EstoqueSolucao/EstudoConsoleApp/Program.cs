namespace EstudoConsoleApp;

using System;
using EstudoConsoleApp.Aulas;
using EstudoConsoleApp.Desafios;

public class Program
{


    public static void Main(string[] args)
    {
        //ExecutarExemplo01();
        //ExecutarExemplo02();
        //ExecutarExemplo03();
        //ExecutarExemplo04();
        //ExecutarExemplo05();
        //-----------------------------------------------------------
        //Desafio01.Executar();
        //Desafio02.Executar();
        //Desafio03.Executar();
        //Desafio04.Executar();
        //Desafio05.Executar();
        //Desafio06.Executar();
        //Desafio07.Executar();
        //Desafio08.Executar();
        //Desafio09.Executar();
        //Desafio10.Executar();
        //-----------------------------------------------------------
        //Desafio01v2.Executar();
        //Desafio02v2.Executar();
        //Desafio03v2.Executar();
        //Desafio04v2.Executar();
        //Desafio05v2.Executar();
        //Desafio06v2.Executar();
        //Desafio07v2.Executar();
        //Desafio08v2.Executar();
        //Desafio09v2.Executar();
        //Desafio10v2.Executar();
        //-----------------------------------------------------------
        //Desafio11.Executar();
        //Desafio12.Executar();
        //Desafio13.Executar();
        Desafio14.Executar();





    }

    private static void ExecutarExemplo01()
    {
        Console.WriteLine("Operacoes Matematicas");

        Console.WriteLine("Informe o primeiro numero");
        int n1 = int.Parse(Console.ReadLine());

        Console.WriteLine("informe o segundo numero");
        int n2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Somar: {0}", OperacoesMatematicas.Somar(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Subtrair: {0}", OperacoesMatematicas.Subtrair(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Mutiplicar: {0}", OperacoesMatematicas.Mutiplicar(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Dividir: {0}", OperacoesMatematicas.Dividir(n1, n2));


        Console.ReadLine();
    }

    private static void ExecutarExemplo02()
    {
        Console.WriteLine("Comparacoes Logicas");
        Console.WriteLine();
        Console.Write("Informe o primeiro numero: ");
        int n1 = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("informe o segundo numero: ");
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine();
        ComparacoesLogicasV2.MaiorQue(n1, n2);
        Console.WriteLine();
        ComparacoesLogicasV2.MenorQue(n1, n2);
        Console.ReadLine();
    }

    private static void ExecutarExemplo03()
    {
        Console.WriteLine("Comparacoes Logicas");
        Console.WriteLine();
        Console.Write("Informe o primeiro numero: ");
        int n1 = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("informe o segundo numero: ");
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine();
        ComparacoesLogicasV2.MaiorQue(n1, n2);
        Console.WriteLine();
        ComparacoesLogicasV2.MenorQue(n1, n2);
        Console.ReadLine();
    }

    private static void ExecutarExemplo04()
    {
        TrabalhandoComDatas.ExibirDataAtual();
        Console.WriteLine();
        TrabalhandoComDatas.ExibirDataAtualFormatada();
        Console.WriteLine();
    }

    private static void ExecutarExemplo05()
    {
        Console.WriteLine("Operacoes Matematicas");

        Console.WriteLine("Informe o primeiro numero");
        int n1 = int.Parse(Console.ReadLine());

        Console.WriteLine("informe o segundo numero");
        int n2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Somar: {0}", OperacoesMatematicas.Somar(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Subtrair: {0}", OperacoesMatematicas.Subtrair(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Mutiplicar: {0}", OperacoesMatematicas.Mutiplicar(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Dividir: {0}", OperacoesMatematicas.Dividir(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Potenciação (x ^ y): {0}", OperacoesMatematicasV2.Potenciacao(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Potenciação (y ^ x): {0}", OperacoesMatematicasV2.Potenciacao(n2, n1));
        Console.WriteLine();
        Console.WriteLine("Radiciação (Raiz quadrada de n1): {0}", OperacoesMatematicasV2.Radiciacao(n1));
        Console.WriteLine();
        Console.WriteLine("Radiciação (Raiz quadrada de n2): {0}", OperacoesMatematicasV2.Radiciacao(n2));
        Console.ReadLine();
    }
}

