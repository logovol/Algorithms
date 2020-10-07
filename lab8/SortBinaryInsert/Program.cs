using System;

namespace SortBinaryInsert
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 7, 3, 9, 1 };

            Sort(arr);
            Print(arr);
            Console.ReadKey();
        }

        private static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }

        static void Sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i <= n - 1; i++)
            {
                int tmp = arr[i];
                int left = 0;
                int right = i - 1;

                while (left <= right)
                {
                    int m = (left + right) / 2;

                    if (tmp < arr[m])
                    {
                        right = m - 1;
                    }
                    else
                    {
                        left = m + 1;
                    }
                }
                for (int j = i - 1; j >= left; j--)
                {
                    arr[j + 1] = arr[j];                    
                }
                arr[left] = tmp;
            }            
        }
    }
}
