using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork4
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

            for (int i = 0; i < height - 1; i++)
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

        /// <summary>
        /// Добавляет случайные числа в дерево. Без вывода команд в консоль.
        /// </summary>
        /// <param name="random"></param>
        /// <param name="binaryTree"></param>
        /// <param name="count"></param>
        public static void AddRandomNumbersSilent(Random random, BinaryTree<string> binaryTree, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int value = random.Next(10, 100);
                binaryTree.Add(value.ToString());
            }
        }

        /// <summary>
        /// Поиск в ширину. Сопровождает работу выводом в консоль. 
        /// </summary>
        /// <param name="value">Искомое значение.</param>
        /// <param name="tree">Дерево, в котором осуществляется поиск.</param>
        /// <returns>Ветвь, в которой найдено значение.</returns>
        public static BinaryTree<T> BreadthFirstSearch(T value, BinaryTree<T> tree)
        {
            Console.WriteLine($"Ищем значение {value}. Осуществляем поиск в ширину.");
            int height = tree.Root.GetHeight();
            Console.WriteLine($"Высота дерева равна {height}");

            List<List<BinaryTree<T>>> branches = new List<List<BinaryTree<T>>>();

            branches.Add(new List<BinaryTree<T>>() { tree.Root });

            for (int i = 0; i < height - 1; i++)
            {
                branches.Add(new List<BinaryTree<T>>());

                foreach (BinaryTree<T> branch in branches[i])
                {
                    if (branch.BranchLeft != null)
                        branches[i + 1].Add(branch.BranchLeft);

                    if (branch.BranchRight != null)
                        branches[i + 1].Add(branch.BranchRight);
                }

                StringBuilder row = new StringBuilder();

                foreach (BinaryTree<T> branch in branches[i])
                {
                    row.Append(branch.Value);
                    row.Append(", ");
                }
                row.Remove(row.Length - 2, 2);

                Console.WriteLine($"Проходим по уровню {i + 1}. В нём содержатся значения: {row}");

                foreach (BinaryTree<T> branch in branches[i])
                {
                    if (value.CompareTo(branch.Value) == 0)
                    {
                        Console.WriteLine($"Значение найдено в уровне {i + 1}.");
                        return branch;
                    }
                }
                Console.WriteLine("Значение не найдено.");
            }

            return null;
        }

        /// <summary>
        /// Поиск в глубину. Сопровождает работу выводом в консоль.
        /// </summary>
        /// <param name="value">Искомое значение.</param>
        /// <param name="tree">Дерево, в котором осуществляется поиск.</param>
        /// <returns>Ветвь, в которой найдено значение.</returns>
        public static BinaryTree<T> DepthFirstSearch(T value, BinaryTree<T> tree)
        {
            if (tree == null)
            {
                Console.WriteLine("Искомый элемент не найден. Возвращаемся.");
                return null;
            }
            else if (value.CompareTo(tree.Value) == 0)
            {
                Console.WriteLine($"Значение элемента равно {tree.Value}. Совпадает с искомым. Возвращаем.");
                return tree;
            }
            else
            {
                if (tree.BranchLeft != null)
                {
                    Console.WriteLine($"Ищем {value} в левом элементе уровня {tree.Depth + 1}. Он равен {tree.BranchLeft.Value}.");
                }
                else
                {
                    Console.WriteLine($"Ищем {value} в левом элементе уровня {tree.Depth + 1}. Он пуст");
                }

                BinaryTree<T> result = DepthFirstSearch(value, tree.BranchLeft);

                if (result == null)
                {
                    if (tree.BranchRight != null)
                    {
                        Console.WriteLine($"Ищем {value} в правом элементе уровня {tree.Depth + 1}. Он равен {tree.BranchRight.Value}.");
                    }
                    else
                    {
                        Console.WriteLine($"Ищем {value} в правом элементе уровня {tree.Depth + 1}. Он пуст");
                    }
                    result = DepthFirstSearch(value, tree.BranchRight);
                }

                return result;
            }
        }
    }
}
