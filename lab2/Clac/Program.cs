using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcRec
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 3;
            int target = 20;
            int counter = 0;
            FindWays(start, target, ref counter);
            Console.WriteLine($"Решение с использованием рекурсии");
            Console.WriteLine($"от {start} до {target} \n{counter} путей");
            Console.ReadLine();
        }

        private static void FindWays(int start, int target, ref int counter)
        {
            if (start == target)
            {
                counter++;
                return;
            }

            if (start > target)
            { 
                return;
            }

            FindWays(start + 1, target, ref counter);
            FindWays(start * 2, target, ref counter);

        }
    }
}
