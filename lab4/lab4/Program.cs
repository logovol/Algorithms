using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    // 3 3
    // 1 1 1
    // 0 1 0
    // 0 1 0
    class Program
    {
        static void Main(string[] args)
        {
            int N = 3;
            int M = 3;

            int[,] Map = { { 1, 1, 1, }, { 0, 1, 0 }, { 1, 1, 0 } };
            int[,] A = new int[M, N];

            bool zero = false;
            for (int s = 0; s < N; s++)
            {
                if (zero)
                {
                    A[0, s] = 0;
                    continue;
                }

                if (Map[0, s] == 0)
                {
                    A[0, s] = 0;
                    zero = true;
                }
                else
                    A[0, s] = 1;
            }

            zero = false;
            for (int k = 0; k < M; k++)
            {
                if (zero)
                {
                    A[k, 0] = 0;
                    continue;
                }

                if (Map[k, 0] == 0)
                {
                    A[k, 0] = 0;
                    zero = true;
                }
                else
                    A[k, 0] = 1;

            }

            int i, j;
            for (i = 1; i < N; i++)
            {
                for (j = 1; j < M; j++)
                {
                    if (Map[i, j] == 1)
                        A[i, j] = A[i, j - 1] + A[i - 1, j];
                    else
                        A[i, j] = 0;
                }

            }
            Print(N, M, A);
            Console.ReadLine();
        }

        static void Print(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.Write($"    {a[i, j]}");
                Console.WriteLine();
            }
        }
    }
}