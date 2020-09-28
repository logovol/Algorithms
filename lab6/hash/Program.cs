using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash
{
    class Program
    {        
        static void Main(string[] args)
        {
            int sizeT = 301;
            string[] list = new string[301];

            while (true)
            {
                Console.Write("Input string: ");
                string data = Console.ReadLine();
                if (data == "0")
                    break;
                int adr = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    adr = Convert.ToInt32(data[i] * (i + 1));
                    adr %= sizeT;
                }
                
                // collisions
                int cnt = 0;
                while (list[adr] != null)
                {
                    if (cnt > 301)
                    {
                        Console.WriteLine("There isn't empty space");
                    }
                    adr = (adr + 13) % sizeT;
                    cnt++;
                }

                list[adr] = data;

                Console.WriteLine(adr);                
            }
        }
    }
}
