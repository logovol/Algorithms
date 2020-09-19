using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5];
            a[0] = 5;
            a[1] = 4;
            a[2] = 3;
            a[3] = 2;
            a[4] = 1;

            Console.Write("Введите искомое число: ");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine($"{FindByBinarySearch(a, x)}");
            
            Console.ReadLine();
        }

        private static int FindByBinarySearch(int[] a, int x)
        {
            int m, left = 0, right = a.Length - 1;

            do
            {
                m = (left + right) / 2;

                if (x > a[m])
                    left = m + 1;
                else
                    right = m - 1;

            }
            while (a[m] != x && left <= right);
            if (a[m] == x)
                return m;
            else
                return -1;

        }
        
    }
}
