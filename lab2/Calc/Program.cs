using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Calc
{
    class Program
    {
        // для перестановок использовал алгоритм Нарайаны
        // ru.wikipedia.org/wiki/Алгоритм_Нарайаны

        static void Main(string[] args)
        {
            int start = 3;
            int target = 20;
            // максимальное количество умножений
            int log = (int)Math.Log(target / 3, 2.0);            
            // минимально необходимое количество колонок
            // чем меньше колонок, тем меньше перестановок
            int arrColumnSize = target - (2 * start) + 1;
            int[,] arr = new int[log + 1, arrColumnSize];
            int counter = 0;

            // 0 - плюс 1
            // 1 - умножить на 2
            for (int i = 1; i < arr.GetLength(0); i++)
            {
                for (int j = arr.GetLength(1) - 1, k = i; j > 0; j--)
                {
                    if (k != 0)
                    {
                        arr[i, j] = 1;
                        k--;
                    }
                }
            }

            List<string> Solves = new List<string>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if(i == 0)
                    counter++;

                bool stop = false;
                while (!stop && i != 0)
                {
                    bool founded = false;
                    for (int j = arr.GetLength(1) - 1; j > 0; j--)
                    {

                        if (arr[i, j - 1] < arr[i, j])
                        {
                            founded = true;                            
                            // нужно найти справа наименьше больший
                            int rightIndex = j;
                            for (int k = j; k < arr.GetLength(1); k++)
                            {
                                if (k < arr.GetLength(1) - 1 && arr[i, k + 1] < arr[i, k] && arr[i, k + 1] > arr[i, j - 1])
                                {
                                    rightIndex = k + 1;
                                }
                            }
                            // перестановка
                            int temp = arr[i, rightIndex];
                            arr[i, rightIndex] = arr[i, j - 1];
                            arr[i, j - 1] = temp;
                            // перестановка готова, теперь перевернуть выражение начиная с a[j]
                            int dif = arr.GetLength(1) - 1 - (j - 1);
                            if (dif > 1)
                            {
                                for (int l = rightIndex, r = arr.GetLength(1) - 1; l < r; l++, r--)
                                {
                                    int templeft = arr[i, l];
                                    arr[i, l] = arr[i, r];
                                    arr[i, r] = templeft;
                                    // тут строка с новой перестановкой готова, можно вычислять
                                    int sum = start;
                                    string solve = string.Empty;
                                    for (int s = 0; s < arr.GetLength(1); s++)
                                    {
                                        if (arr[i, s] == 0)
                                        {
                                            solve += 0;
                                            sum += 1;
                                        }
                                        else if (arr[i, s] == 1)
                                        {
                                            solve += 1;
                                            sum *= 2;
                                        }

                                        if (sum == target)
                                        {
                                            if (!Solves.Contains(solve))
                                            {
                                                counter++;
                                                Solves.Add(solve);
                                            }                                            
                                            break;
                                        }    
                                    }
                                }
                                j = arr.GetLength(1) - 1;
                            }

                        }
                        else if (j == 1 && !founded)
                        {
                            stop = true;
                        }

                    }
                }
            }

            Console.WriteLine($"Решение с использованием массива");
            Console.WriteLine($"от {start} до {target} \n{counter} путей\n");
            Console.WriteLine("Обозначения: 0 - прибавить 1; 1 - умножить на 2\n");

            Console.Write("1) ");
            for (int i = 0; i < target - start; i++)
            {
                Console.Write("0");
            }
            Console.WriteLine();
            for (int i = 0; i < Solves.Count; i++)
            {
                Console.WriteLine($"{i + 2}) {Solves[i]}");
            }

            Console.ReadLine();
        }
    }
}

