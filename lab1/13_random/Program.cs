using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_random
{
    // 13. * Написать функцию, генерирующую случайное число от 1 до 100.
    // с использованием стандартной функции rand()
    // без использования стандартной функции rand()

    class Program
    {
        static void Main(string[] args)
        {
            // часть 1
            Console.WriteLine("генератор Random");
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rnd.Next(1, 101));
            }            

            // часть 2
            Console.WriteLine("Свой генератор: ru.wikipedia.org/wiki/Линейный_конгруэнтный_метод");
            MyRandom rand = new MyRandom(100);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rand.Next());
            }
            Console.ReadLine();
        }
    }  

}
