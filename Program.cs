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
        static long tamanho = 50000;
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

        static void Bolha_Otimizado(List<int> elementos)
        {
            //List<int> elementos = new List<int>();
            int varreduras = 0;
            //bool opcao = true;
            bool trocou = false;

            //while (opcao)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Informe o número: ");
            //    elementos.Add(int.Parse(Console.ReadLine()));

            //    Console.WriteLine("Deseja inserir outro número? [s/n]");
            //    opcao = Console.ReadLine() == "s" ? true : false;
            //    //operação ternária
            //}

            //Ordenação utilizando o Bubble Sort
            for (int i = 0; i < elementos.Count - 1; i++)
            {
                trocou = false;
                varreduras++;
                for (int ord = 0; ord < elementos.Count - 1; ord++)
                {
                    int temp = 0;
                    if (elementos[ord] > elementos[ord + 1])
                    {
                        temp = elementos[ord + 1];
                        elementos[ord + 1] = elementos[ord];
                        elementos[ord] = temp;

                        trocou = true;
                    }
                }
                if (!trocou) break;
            }
            //Console.WriteLine(varreduras);

            //foreach (int item in elementos)
            //    Console.Write(item + " ");

            //Console.ReadKey();

        }

        static void selection_sort(List<int> elementos)
        {
            //List<char> container_letras = new List<char>();
            //bool escolha = true;

            //while (escolha)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Informe uma letra [a~z]: ");
            //    container_letras.Add(char.Parse(Console.ReadLine().ToLower()));


            //    Console.WriteLine("Deseja inserir outra letra? [s/n]");

            //    //operação ternaria <condição> ? <operação1> : <operação2>
            //    escolha = Console.ReadLine() == "s" ? true : false;
            //}

            for (int i = 0; i < elementos.Count; i++)
            {
                int temp;
                int min = i;
                for (int elem = i + 1; elem < elementos.Count; elem++)
                    if (elementos[elem] < elementos[min]) min = elem; //Encontra o menor elemento

                //2 4 7 5 1

                //trocar o menor com o elementop da pos. atual
                temp = elementos[i];
                elementos[i] = elementos[min];
                elementos[min] = temp;
            }

            //foreach (int item in elementos)
            //    Console.Write(item + " ");
        }

        static void insertionSort(List<int> elementos)
        {
            //int[] elementos = new int[5];
            //int contElementos = 0;

            //while (contElementos < 5)
            //{
            //    Console.WriteLine("Informe os números: ");
            //    elementos[contElementos] = int.Parse(Console.ReadLine());
            //    contElementos++;
            //}

            int temp = 0;

            //Inicia na posição 1 pois a primeira ja contem o primeiro elemento
            for (int i = 1; i < elementos.Count; i++)
            {
                //compara o atual com o anterior
                //verifica se é maior que zero para garantir que tenha um anterior
                for (int elem = i; elem > 0 && elementos[elem] < elementos[elem - 1]; elem--)
                {

                    temp = elementos[elem - 1];
                    elementos[elem - 1] = elementos[elem];
                    elementos[elem] = temp;
                }
            }

            //foreach (int item in elementos)
            //    Console.Write(item + " ");

            //Console.ReadKey();
        }


        public static List<int> MergeSort(List<int> container_elementos)
        {
            if (container_elementos.Count < 2)
                return container_elementos;

            int metade = container_elementos.Count / 2;

            List<int> container_esquerda = new List<int>();
            List<int> container_direita = new List<int>();

            for (int x = 0; x < metade; x++) //0 até < metade
                container_esquerda.Add(container_elementos[x]);

            for (int x = metade; x < container_elementos.Count; x++)
                container_direita.Add(container_elementos[x]);


            return Merge(MergeSort(container_esquerda), MergeSort(container_direita));
        }

        public static List<int> Merge(List<int> container_esquerda, List<int> container_direita)
        {
            List<int> container_ordenado = new List<int>();

            int temp_esq = 0, temp_dir = 0;


            while (temp_esq < container_esquerda.Count && temp_dir < container_direita.Count)
                if (container_esquerda[temp_esq] < container_direita[temp_dir])
                {
                    container_ordenado.Add(container_esquerda[temp_esq]);
                    temp_esq++;
                }
                else
                {
                    container_ordenado.Add(container_direita[temp_dir]);
                    temp_dir++;
                }


            while (temp_esq < container_esquerda.Count)
            {
                container_ordenado.Add(container_esquerda[temp_esq]);
                temp_esq++;
            }

            while (temp_dir < container_direita.Count)
            {
                container_ordenado.Add(container_direita[temp_dir]);
                temp_dir++;
            }

            return container_ordenado;
        }

        static void Main(string[] args)
        {
            Stopwatch tempo = new Stopwatch();

            tamanho = 1000;
            Console.WriteLine("Elementos: " + tamanho);
            tempo.Start();
            dados();
            tempo.Stop();
            Console.WriteLine("Tempo Randon: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Restart();
            Bolha_Otimizado(elementos);
            tempo.Stop();
            Console.WriteLine("Bubble Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            selection_sort(elementos);
            tempo.Stop();
            Console.WriteLine("Selection Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            insertionSort(elementos);
            tempo.Stop();
            Console.WriteLine("Insertion Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            MergeSort(elementos);
            tempo.Stop();
            Console.WriteLine("Merge Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Reset();
            Console.WriteLine();


            //5000
            tamanho = 5000;
            Console.WriteLine("Elementos: " + tamanho);
            tempo.Start();
            dados();
            tempo.Stop();
            Console.WriteLine("Tempo Randon: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Restart();
            Bolha_Otimizado(elementos);
            tempo.Stop();
            Console.WriteLine("Bubble Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            selection_sort(elementos);
            tempo.Stop();
            Console.WriteLine("Selection Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            insertionSort(elementos);
            tempo.Stop();
            Console.WriteLine("Insertion Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            MergeSort(elementos);
            tempo.Stop();
            Console.WriteLine("Merge Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Reset();
            Console.WriteLine();


            //10000
            tamanho = 10000;
            Console.WriteLine("Elementos: " + tamanho);
            tempo.Start();
            dados();
            tempo.Stop();
            Console.WriteLine("Tempo Randon: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Restart();
            Bolha_Otimizado(elementos);
            tempo.Stop();
            Console.WriteLine("Bubble Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            selection_sort(elementos);
            tempo.Stop();
            Console.WriteLine("Selection Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            insertionSort(elementos);
            tempo.Stop();
            Console.WriteLine("Insertion Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            MergeSort(elementos);
            tempo.Stop();
            Console.WriteLine("Merge Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Reset();
            Console.WriteLine();


            //50000
            tamanho = 50000;
            Console.WriteLine("Elementos: " + tamanho);
            tempo.Start();
            dados();
            tempo.Stop();
            Console.WriteLine("Tempo Randon: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Restart();
            Bolha_Otimizado(elementos);
            tempo.Stop();
            Console.WriteLine("Bubble Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            selection_sort(elementos);
            tempo.Stop();
            Console.WriteLine("Selection Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            insertionSort(elementos);
            tempo.Stop();
            Console.WriteLine("Insertion Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            MergeSort(elementos);
            tempo.Stop();
            Console.WriteLine("Merge Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Reset();
            Console.WriteLine();


            //100000
            tamanho = 100000;
            Console.WriteLine("Elementos: " + tamanho);
            tempo.Start();
            dados();
            tempo.Stop();
            Console.WriteLine("Tempo Randon: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Restart();
            Bolha_Otimizado(elementos);
            tempo.Stop();
            Console.WriteLine("Bubble Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            selection_sort(elementos);
            tempo.Stop();
            Console.WriteLine("Selection Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            insertionSort(elementos);
            tempo.Stop();
            Console.WriteLine("Insertion Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            MergeSort(elementos);
            tempo.Stop();
            Console.WriteLine("Merge Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Reset();
            Console.WriteLine();

            //200000
            tamanho = 200000;
            Console.WriteLine("Elementos: " + tamanho);
            tempo.Start();
            dados();
            tempo.Stop();
            Console.WriteLine("Tempo Randon: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Restart();
            Bolha_Otimizado(elementos);
            tempo.Stop();
            Console.WriteLine("Bubble Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            selection_sort(elementos);
            tempo.Stop();
            Console.WriteLine("Selection Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            insertionSort(elementos);
            tempo.Stop();
            Console.WriteLine("Insertion Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            MergeSort(elementos);
            tempo.Stop();
            Console.WriteLine("Merge Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Reset();
            Console.WriteLine();


            //300000
            tamanho = 300000;
            Console.WriteLine("Elementos: " + tamanho);
            tempo.Start();
            dados();
            tempo.Stop();
            Console.WriteLine("Tempo Randon: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Restart();
            Bolha_Otimizado(elementos);
            tempo.Stop();
            Console.WriteLine("Bubble Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            selection_sort(elementos);
            tempo.Stop();
            Console.WriteLine("Selection Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            insertionSort(elementos);
            tempo.Stop();
            Console.WriteLine("Insertion Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));

            tempo.Restart();
            MergeSort(elementos);
            tempo.Stop();
            Console.WriteLine("Merge Sort: " + tempo.Elapsed.ToString("mm\\:ss\\.ff"));
            tempo.Reset();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
