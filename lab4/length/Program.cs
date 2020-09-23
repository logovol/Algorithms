using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace length
{
    class Program
    {
        static void Main(string[] args)
        {
            string word1 = "geekbrains";
            string word2 = "geekminds";
            Console.WriteLine($"Слово №1 {word1}");
            Console.WriteLine($"Слово №2 {word2}");            

            int w1Length = word1.Length;
            int w2Length = word2.Length;            

            int[,] matrix = new int[w1Length + 1, w2Length + 1];

            for (int i = 1; i <= w1Length; i++)
            {
                for (int j = 1; j <= w2Length; j++)
                {                    
                    if (word1[i - 1] == word2[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }   

            List<char> LCS = new List<char>();
            int k = w1Length - 1, m = w2Length - 1;
            while (k >= 0 && m >= 0)
                if (word1[k] == word2[m])
                { 
                    LCS.Add(word1[k]);
                    k--;
                    m--;
                }
                else if (matrix[k - 1, m] > matrix[k, m - 1])
                    k--;
                else
                    m--;
            LCS.Reverse();

            Console.Write($"Общая наибольшая подпоследовательность: ");
            foreach (var item in LCS)
            {
                Console.Write(item);
            }           
                        
            Console.WriteLine($"\nДлина: {matrix[w1Length, w2Length]}");
            Console.ReadLine();
        }
    }
}
