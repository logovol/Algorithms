using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_years
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 150; i++)
            {
                int c = DigitNumber(i);
                int num = i % 10;

                if (i % 100 >= 11 && i % 100 <= 14)
                {
                    Console.WriteLine($"{i} лет");
                }
                else if (num >= 5 && num <= 9 || num == 0)
                    Console.WriteLine($"{i} лет");
                else if (num >= 2 && num <= 4)
                    Console.WriteLine($"{i} года");
                else
                    Console.WriteLine($"{i} год");
            }

            Console.ReadLine();
        }

        private static int DigitNumber(int num)
        {
            int c = 0;
            while (num > 0)
            {
                num /= 10;
                c++;
            }
            
            return c;
        }
    }
}
