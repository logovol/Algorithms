using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortShaker
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5];
            a[0] = 3;
            a[1] = 2;
            a[2] = 4;
            a[3] = 5;
            a[4] = 1;            

            Print(a);
            SortShaker(a);
            Print(a);

            Console.ReadLine();
        }

        private static void Print(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine();
        }

        private static void SortShaker(int[] a)
        {
            int left = 1, right = a.Length - 1, last = right;
            int counter = 0;

            do
            {
                for (int j = right; j >= left; j--)
                {
                    counter++;
                    if (a[j - 1] > a[j])
                    {                        
                        int t = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = t;
                        last = j;
                    }
                }

                left = last;
                for (int j = left; j <= right; j++)
                {
                    counter++;
                    if (a[j - 1] > a[j])
                    {                        
                        int t = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = t;
                        last = j;
                    }
                }

                right = last - 1;
            }
            while (left < right);            
            Console.WriteLine($"{a.Length} элементов, {counter} операций, сложность алогритма (средний случай) O(N^2)");
        }
    }
}
