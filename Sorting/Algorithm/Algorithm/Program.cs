using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Skriv in storleken på den array av heltal som skall sorteras: ");
            int size = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Skall talen skrivas ut? (y/n)");
            string print = Console.ReadLine();

            Console.WriteLine("Skapar slumpad data av längd " + size);
            int[] data = GenerateData(size);
            //if (print == "y")
            //{
            //    PrintArray(data);
            //}           
            Console.WriteLine("Startar algoritmen");
            DateTime startTid = DateTime.Now;

            //Skriv in anropet till metoden här
            int length = data.Length;   
            Quicksort(data, 0, length - 1);

            TimeSpan deltaTid = DateTime.Now - startTid;
            if (print == "y")
            {
                PrintArray(data);
            }
            Console.WriteLine("Det tog {0:0.00} ms att sortera.\n", deltaTid.TotalMilliseconds);
            Console.ReadKey();
        }
        
        static void PrintArray(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i]);
            }
        }

        static int[] GenerateData(int size)
        {
            int[] data = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                data[i] = random.Next(0, size + 1);
            }

            //Denna metod skall skapa en int-array och fylla den med slumptal
            return data;
        }

        public static void Quicksort(int[] A, int left, int right)
        {
            /*
            If left is greater than right or either of the numbers is less than zero, return.
            Do this to prevent that it sorts in the wrong direction and if either of the numbers
            is zero it is invalid*/
            if (left > right || left < 0 || right < 0) return;

            //Get the index that is last
            int index = Partition(A, left, right);

            //Make sure that the index isn't negative 1
            if (index != -1)
            {
                //Call the Quicksort method until it is done sorting
                Quicksort(A, left, index - 1);
                Quicksort(A, index + 1, right);
            }
        }

        //Splits the array into two sections
        private static int Partition(int[] A, int left, int right)
        {
            if (left > right) return -1;

            int end = left;

            int pivot = A[right];    // choose last one to pivot, easy to code
            for (int i = left; i < right; i++)
            {
                if (A[i] < pivot)
                {
                    Swap(A, i, end);
                    end++;
                }
            }

            Swap(A, end, right);

            return end;
        }

        //Swaps the position of the ints in an array
        private static void Swap(int[] A, int left, int right)
        {
            int tmp = A[left];
            A[left] = A[right];
            A[right] = tmp;
        }

    }

}
