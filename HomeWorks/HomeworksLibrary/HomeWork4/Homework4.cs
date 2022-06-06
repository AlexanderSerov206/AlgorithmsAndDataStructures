using HomeworksLibrary.HomeWork4;
using IHomeworkLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork4
{
    internal class Homework4 : IHomework
    {
        [Display(Name = "Задание 4.1", Description = "Бинарное дерево.")]
        public static void HomeWork_4_1()
        {
            Random random = new Random();
            BinaryTree<string> binaryTree = new BinaryTree<string>(random.Next(10, 100).ToString());

            BinaryTreeHandler<string>.AddRandomNumbers(random, binaryTree, 15);
            BinaryTreeHandler<string>.PrintTree(binaryTree);
            BinaryTreeHandler<string>.SearchForRandomNumbers(random, binaryTree, 5);
        }

        [Display(Name = "Задание 4.2", Description = "Hash-таблицы и массивы.")]
        public static void HomeWork_4_2()
        {
            Random random = new Random();
            int count = 200000;
            string[] stringArray = new string[count];
            HashSet<string> stringHashSet = new HashSet<string>(count);

            TimeSpan arrayFillElapsed = ArrayPerformanceCalculator.ArrayFillPerformance(random, count, stringArray);
            TimeSpan hashSetFillElapsed = HashSetPerformanceCalculator.HashSetFillPerformance(random, count, stringHashSet);

            Console.WriteLine($"Массив {count} строк заполнен за {arrayFillElapsed}");
            Console.WriteLine($"HashSet {count} строк заполнен за {hashSetFillElapsed}");

            TimeSpan arraySearchElapsed = ArrayPerformanceCalculator.SearchRandomWordArray(random, stringArray);
            TimeSpan hashSetSearchElapsed = HashSetPerformanceCalculator.SearchRandomWordHashSet(random, stringHashSet);

            Console.WriteLine($"Проверка наличия случайного слова в массиве выполнена за {arraySearchElapsed}");
            Console.WriteLine($"Проверка наличия случайного слова в HashSet выполнена за {hashSetSearchElapsed}");
        }

        [Display(Name = "Задание 5", Description = "Бинарные деревья. Поиск в ширину и в глубину.")]
        public static void HomeWork_5_1()
        {
            Random random = new Random();
            BinaryTree<string> binaryTree = new BinaryTree<string>(random.Next(10, 100).ToString());
            BinaryTreeHandler<string>.AddRandomNumbersSilent(random, binaryTree, 50);

            string valueToSearch = random.Next(10, 100).ToString();

            BinaryTreeHandler<string>.DepthFirstSearch(valueToSearch, binaryTree);

            Console.WriteLine();

            BinaryTreeHandler<string>.BreadthFirstSearch(valueToSearch, binaryTree);
        }
    }
}
