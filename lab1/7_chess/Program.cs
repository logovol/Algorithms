using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _7_chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты клетки шахматной доски");
            Console.Write("x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("y: ");
            int y = int.Parse(Console.ReadLine());

            if (x > 0 && x <= 8 && y > 0 && y <= 8)
            {
                if (Odd(x) && Odd(y) || !Odd(x) && !Odd(y))
                    Console.WriteLine("Черная клетка");
                else
                    Console.WriteLine("Белая клетка");
            }
            else
            {
                Console.WriteLine("Шахматная доска не содержит такие координаты");
            }
            
            Console.ReadLine();
        }

        private static bool Odd(int x)
        {
            if (x % 2 == 0)
                return false;
                
            return true;
        }
    }
}
