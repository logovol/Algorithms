using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static int[] arr = { 9, 3, 6, 7, 5, 3, 4 };
        static void Main(string[] args)
        {   
            QuickS(0, arr.Length - 1);
            Print();
            Console.ReadKey();
        }


        static void QuickS(int left, int right)
        {
            int i = left; int j = right;
            int x = arr[(left + right) / 2]; // средний элемент

            do
            {
                while (arr[i] < x)
                    // поиск элемента больше среднего
                    i++;
                while (arr[j] > x)
                    // поиск элемента меньше среднего
                    j--;
                if (i <= j) // обмен элементов местами
                {
                    int tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                }
            } while (i<=j);

            if (left < j)
                QuickS(left, j); // левый подмассив
            if (i < right)
                QuickS(i, right); // правый подмассив
        }

        static void Print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}
