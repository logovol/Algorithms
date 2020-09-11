using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Лях Павел
//14. * Автоморфные числа.Натуральное число называется автоморфным, если оно равно последним
//цифрам своего квадрата.Например, 25 \ :sup: `2` = 625. Напишите программу, которая вводит
//натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.


namespace _14_automorph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Поиск автоморфных чисел");
            Console.WriteLine("Введите натуральное число N (до какого числа произвести поиск)");
            ulong n = ulong.Parse(Console.ReadLine());

            for (ulong i = 0; i <= n; i++)
            {
                if (isAutomorph(i))
                {
                    Console.WriteLine(i);
                }
            }            

            Console.ReadLine();
        }

        private static bool isAutomorph(ulong n)
        {
            ulong p = n * n;
            ulong c = DigitNumber(n);
            if (p % (ulong)Math.Pow(10, (ulong) c) == n)
            {
                return true;
            }
            
            return false;
        }

        private static ulong DigitNumber(ulong n)
        {
            ulong c = 0;
            while (n > 0)
            {
                n /= 10;
                c++;
            }

           return c;
        }
    }
}
