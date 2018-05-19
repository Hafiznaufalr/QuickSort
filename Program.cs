using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick_Sort
{
    class Program
    {
        static ArrayList data;
        static int numElements;


        private static void swap(ArrayList data, int x, int y)
        {
            int temp;
            temp = Convert.ToInt16(data[x]);
            data[x] = data[y];
            data[y] = temp;

        }


        private static int partition
        (ArrayList data, int left, int right)

        // Syarat : left <= right
        // Hasil : data[left] ditempatkan 
        // di lokasi yang sesuai.
        {
            while (true)
            {
                while (left < right &&
                    Convert.ToInt16(data[left]) < Convert.ToInt16(data[right])) right--;
                if (left < right) swap(data, left + 1, right);
                else return left;

                while (left < right &&
                    Convert.ToInt16(data[left]) < Convert.ToInt16(data[right])) left++;
                if (left < right) swap(data, left, right--);
                else return right;
            }
        }

        private static void DisplayElements()
        {
            for (int i = 0; i < numElements; i++)
            {
                Write(" " + data[i] + " ");
            }
            WriteLine();
        }

        public static void quickSort(ArrayList data, int n)
        {
            quickSortRecursive(data, 0, n - 1);
        }

        private static void quickSortRecursive(ArrayList data, int left, int right)
        // Syarat : left <= right
        // Hasil akhir : data[left..right] dalam keadaan 
        // urut naik (ascending)
        {
            int pivot;
            if (left >= right) return;

            pivot = partition(data, left, right);

            quickSortRecursive(data, left, pivot - 1);

            quickSortRecursive(data, pivot + 1, right);

            DisplayElements();

        }

        static void Main(string[] args)
        {
            Write
            ("Berapa elemen array yang akan diurutkan ?  ");
            numElements = int.Parse(ReadLine());
            data = new ArrayList(numElements);

            Random mRandom = new Random(100);

            for (int i = 0; i < numElements; i++)
                data.Add((int)(mRandom.NextDouble() * 100));
            WriteLine("\nBilangan awal : ");

            DisplayElements();

            WriteLine();

            quickSort(data, numElements);

            WriteLine("\nBilangan terurut : \n");

            DisplayElements();

            ReadLine();
        }
    }
}