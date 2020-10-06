using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DijkstraAlgorithm
{
    class Dijkstra
    {
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Вершина    Расстояние от источника");

            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }

        public static void DijkstraAlg(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            Print(distance, verticesCount);
        }

        static void Main(string[] args)
        { 
            int[,] graph =  {
                         { 0, 4, 8, 3, 0, 0, 0, 0 },
                         { 4, 0, 1, 0, 8, 5, 0, 0 },
                         { 8, 1, 0, 8, 2, 0, 0, 0 },
                         { 3, 0, 8, 0, 0, 0, 4, 0 },
                         { 0, 8, 2, 0, 0, 2, 0, 5 },
                         { 0, 5, 0, 0, 2, 0, 0, 3 },
                         { 0, 0, 0, 4, 0, 0, 0, 2 },
                         { 0, 0, 0, 0, 5, 3, 2, 0 }
                            };

            DijkstraAlg(graph, 4, 8);
            Console.ReadKey();
        }
    }
}