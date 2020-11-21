using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Algoritmo_Desempenho
{
   
    class Program
    {
        static long tamanho = 100000000;
        static List<int> elementos = new List<int>();

        static void dados()
        {
            elementos = new List<int>();
            for (long i = 0; i < tamanho; i++)
            {
                Random aleatorio = new Random();
                int num = aleatorio.Next((Int32)i, (Int32)tamanho);

                elementos.Add(num);
            }
        }

        static void Main(string[] args)
        {
            Stopwatch tempo = new Stopwatch();

            Console.WriteLine("Iniciando..");
            Console.WriteLine("Gerando valores...");
            tempo.Start();
            dados();//substituir pelo método de ordenação
            tempo.Stop();
            Console.WriteLine("Resultado: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            Console.ReadLine();
        }
    }
}
