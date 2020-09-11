using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ru.wikipedia.org/wiki/Линейный_конгруэнтный_метод
namespace _13_random
{
    public class MyRandom
    {
        private int max;
        private int X;
                
        public MyRandom(int max)
        {
            this.max = max;
            X = (int)(DateTime.Now.Millisecond % max);
        }
        
        public int Next()
        {
            X = (X * 12345 + 2) % 12354;
            if (X % max == 0)
                return 1;

            return X % max;
        }
    }
}
