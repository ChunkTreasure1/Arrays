using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmer
{
    class Program
    {
        static int MaxLength = 0;
        static int TempLength = 0;

        static void Main(string[] args)
        {
            Random randomn = new Random();
            int[] arrn = new int[100];

            for (int i = 0; i < arrn.Length; i++)
            {
                arrn[i] = randomn.Next(1, 10);
                Console.WriteLine(arrn[i]);
            }

            Mates(arrn);
            Console.ReadKey();

            Console.WriteLine("1. Pathfinding");
            Console.WriteLine("2. LongestSerie");

            Console.Write("Choose option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                char[,] path = 
                { 
                    { '█', '█', '█', 'M'}, 
                    { '█', '█', '█', '█'}, 
                    { '█', 'X', 'X', 'X'},
                    { 'S', '█', '█', '█'}
                };

                PrintPath(path);
                PathFinding(path);
            }
            else if (choice == 2)
            {
                int[] arr = new int[100];
                Random random = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = random.Next(0, 20);
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }

                Console.WriteLine("Längsta: " + LongestSerie(arr, 0, arr[0]));
            }

            //NumberSerie(0);
            Console.ReadKey();
        }

        static void PrintPath(char[,] path)
        {
            for (int i = 0; i < path.GetLength(0); i++)
            {
                for (int j = 0; j < path.GetLength(1); j++)
                {
                    Console.Write(path[i, j] + " ");
                }
                Console.Write(Environment.NewLine);
            }
        }

        static int LongestSerie(int[] arr, int i, int n)
        {
            if (i >= arr.Length)
            {
                return MaxLength;
            }

            if (arr[i] != n && TempLength > MaxLength)
            {
                MaxLength = TempLength;
                TempLength = 0;
            }

            if (arr[i] == n)
            {
                TempLength++;
                return LongestSerie(arr, i + 1, n);
            }
            else
            {
                TempLength = 0;
                TempLength++;
                return LongestSerie(arr, i + 1, arr[i]);
            }
        }

        static int NumberSerie(int n)
        {
            if (n > 1000)
            {
                return n;
            }
            Console.WriteLine(n);
            return NumberSerie(n + 5);
        }

        static int[] GetStartPos(char[,] path)
        {
            int y = 0;

            for (int i = path.GetLength(0) - 1; i >= 0; i--, y++)
            {
                for (int j = path.GetLength(1) - 1; j >= 0; j--)
                {
                    if (path[i, j] == 'S')
                    {
                        int[] pos = { y + 1, j + 1};
                        return pos;
                    }
                }
            }
            return new int[0];
        }

        static void PathFinding(char[,] path)
        {
            int[] startPos = GetStartPos(path);

            Console.WriteLine(startPos[0] + ", " + startPos[1]);
        }

        static int LowestNumber(int[] arr)
        {
            int max = arr.Max();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        static void Mates(int[] arr)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i != 0)
                {
                    if (arr[i] + arr[i - 1] == 10 && !indexes.Contains(arr[i - 1]))
                    {
                        indexes.Add(i);
                        indexes.Add(i - 1);
                        Console.WriteLine(arr[i] + " + " + arr[i - 1] + " = 10");
                    }
                }
            }
        }
    }
}
