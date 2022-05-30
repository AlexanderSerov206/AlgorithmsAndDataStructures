using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks.HomeWork4
{
    public static class BinaryTreeHandler<T> where T : IComparable
    {
        /// <summary>
        /// Отрисовывает бинарное дерево в консоль.
        /// </summary>
        /// <param name="tree"></param>
        public static void PrintTree(BinaryTree<T> tree)
        {
            Console.WriteLine(new StringBuilder().Append('_', Console.BufferWidth));

            List<List<BinaryTree<T>>> trees = GetBranches(tree);

            int maximumElementWidth = trees.Max(x => x.Max(y => y.Value != null ? y.Value.ToString().Length : 0));

            foreach (List<BinaryTree<T>> branches in trees)
            {
                int indentWidth = (Console.BufferWidth / Convert.ToInt32(Math.Pow(2, trees.IndexOf(branches) + 1)) - (maximumElementWidth / 2));

                StringBuilder indent = new StringBuilder(Console.BufferWidth);
                indent.Append(' ', indentWidth);

                StringBuilder row = new StringBuilder();

                foreach (BinaryTree<T> branch in branches)
                {
                    row.Append(indent);
                    row.Append(branch.Value == null ? "?" : branch.Value);
                    row.Append(indent);
                }

                Console.Write($"{row}\n\n");
            }
            Console.WriteLine(new StringBuilder().Append('_', Console.BufferWidth));
        }

        /// <summary>
        /// Конвертация дерева в список ветвей для отрисовки.
        /// </summary>
        /// <param name="rootTree"></param>
        /// <returns></returns>
        private static List<List<BinaryTree<T>>> GetBranches(BinaryTree<T> rootTree)
        {
            int height = rootTree.GetHeight();

            List<List<BinaryTree<T>>> branches = new List<List<BinaryTree<T>>>();

            branches.Add(new List<BinaryTree<T>>() { rootTree });

            for (int i = 0; i < height -1; i++)
            {
                branches.Add(new List<BinaryTree<T>>());

                foreach (BinaryTree<T> branch in branches[i])
                {
                    if (branch.BranchLeft != null)
                        branches[i + 1].Add(branch.BranchLeft);
                    else
                        branches[i + 1].Add(new BinaryTree<T>(default(T)));

                    if (branch.BranchRight != null)                    
                        branches[i + 1].Add(branch.BranchRight);
                    else
                        branches[i + 1].Add(new BinaryTree<T>(default(T)));
                }
            }

            return branches;
        }

        /// <summary>
        /// Ищет случайные числа в дереве.
        /// </summary>
        /// <param name="random"></param>
        /// <param name="binaryTree"></param>
        /// <param name="count"></param>
        public static void SearchForRandomNumbers(Random random, BinaryTree<string> binaryTree, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int value = random.Next(100);

                if (binaryTree.Search(value.ToString()) != null)
                {
                    Console.WriteLine($"Число {value} найдено в дереве!");
                }
                else
                {
                    Console.WriteLine($"Число {value} не найдено в дереве!");
                }
            }
        }
        
        /// <summary>
        /// Добавляет случайные числа в дерево
        /// </summary>
        /// <param name="random"></param>
        /// <param name="binaryTree"></param>
        /// <param name="count"></param>
        public static void AddRandomNumbers(Random random, BinaryTree<string> binaryTree, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int value = random.Next(10, 100);
                if (binaryTree.Add(value.ToString()))
                {
                    Console.WriteLine($"Элемент {value} добавлен в дерево. Количетсво элементов = {binaryTree.Count}");
                }
                else
                {
                    Console.WriteLine($"Элемент {value} не был добавлен, т.к. есть дубль. Количетсво элементов = {binaryTree.Count}");
                }
            }
        }
    }
}
