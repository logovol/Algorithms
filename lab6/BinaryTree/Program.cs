using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{

//    Переписать программу, реализующее двоичное дерево поиска.
//  а) Добавить в него обход дерева различными способами;
//  б) Реализовать поиск в двоичном дереве поиска;

    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();

            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(1);
            binaryTree.Add(6);
            binaryTree.Add(4);
            binaryTree.Add(7);
            binaryTree.Add(14);
            binaryTree.Add(16);            

            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(3);
            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(8);
            binaryTree.PrintTree();


            if (binaryTree.RootNode != null)
            {
                Console.WriteLine();
                string t = "Прямой обход в глубину: ";
                t = binaryTree.NLR(binaryTree.RootNode, ref t);
                Console.WriteLine(t);

                string t1 = "Обход дерева в ширину: ";
                t1 = binaryTree.BFS(binaryTree.RootNode, ref t1);
                Console.WriteLine(t1);
                
                string t2 = "Симметричный обход: ";
                binaryTree.Simetrical(binaryTree.RootNode, ref t2);
                Console.WriteLine(t2);

                string t3 = "Обратный обход: ";
                binaryTree.LRN(binaryTree.RootNode, ref t3);
                Console.WriteLine(t3);
            }


            Console.ReadLine();
        }
    }
}
