using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortBubl
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
            SortBuble(a);
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

        private static void SortBuble(int[] a)
        {
            int N = a.Length;
            int counter = 0;
                        
            for (int i = 0; i < N; i++)
            {
                bool change = false;                
                for (int j = 0; j < N - 1; j++)
                {                    
                    counter++;
                    if (a[j] > a[j + 1])
                    {                        
                        int t = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = t;
                        change = true;
                    }
                }
                if (!change)
                  break;
            }
            Console.WriteLine($"{N} элементов, {counter} операций, сложность алогритма O(N^2)");
        }
    }
}
