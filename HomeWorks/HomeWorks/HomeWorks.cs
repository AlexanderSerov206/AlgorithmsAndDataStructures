using HomeWorks.HomeWork1;
using HomeWorks.HomeWork2;
using HomeWorks.HomeWork3;
using HomeWorks.HomeWork4;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace HomeWorks
{
    /// <summary>
    /// Класс для размещения методов, которые будут запускать проверку домашних заданий.
    /// </summary>
    static class HomeWorks
    {
        [Display(Name = "Задание 1.1", Description = "Проверка простых чисел.")]
        public static void HomeWork_1_1()
        {
            bool expectedTrue = NumberChecker.IsNumberSimple_11_True();
            bool expectedFalse = NumberChecker.IsNumberSimple_10_False();

            Console.WriteLine($"Проверка числа 11 на простоту, ожидаемый результат - true. Результат работы теста - {expectedTrue}");
            Console.WriteLine($"Проверка числа 10 на простоту, ожидаемый результат - false. Результат работы теста - {expectedFalse}");

            Console.WriteLine();
            Console.WriteLine("Введите число для проверки на простоту.");

            if (int.TryParse(Console.ReadLine(), out int number) && number > 1)
            {
                switch (NumberChecker.IsNumberSimple(number))
                {
                    case true:
                        Console.WriteLine($"Число {number} является простым!");
                        break;

                    case false:
                        Console.WriteLine($"Число {number} не является простым!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Введено некорректное значение.");
            }
        }

        [Display(Name = "Задание 1.3", Description = "Расчёт числа Фибоначчи.")]
        public static void HomeWork_1_3()
        {
            Console.WriteLine();
            Console.WriteLine("Введите порядковый номер вычисляемого числа последовательности Фибоначчи.");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine($"Число Фибоначчи рекурсивным методом: {FibonacciCalculator.GetFibonacciNumberRecursive(number)}");
                Console.WriteLine($"Число Фибоначчи циклом: {FibonacciCalculator.GetFibonacciNumberNonRecursive(number)}");
            }
            else
            {
                Console.WriteLine("Введено некорректное значение.");
            }
        }

        [Display(Name = "Задание 2", Description = "Двусвязный список.")]
        public static void HomeWork_2_1()
        {
            LinkedList linkedList = new LinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
            int count = linkedList.GetCount();

            Console.WriteLine($"Создан двусвязанный список из массива целых чисел от 1 до 20. Длина списка {count} элементов.");

            Node node = linkedList.FirstNode;

            Console.WriteLine("Вывод элементов списка по порядку от начала.");
            do
            {
                Console.Write($"{node.Value}, ");
                node = node.NextNode;
            } while (node != null);

            Console.WriteLine();
            Node foundNode = linkedList.FindNode(5);
            Console.WriteLine(@$"Поиск узла со значением 5. Предыдущее значение - {foundNode.PrevNode.Value}, следующее значение - {foundNode.NextNode.Value}, индекс найденного элемента - {linkedList.GetNodeIndex(foundNode)}.");

            Console.WriteLine($"Удаляем первый элемент из списка по индексу.");
            linkedList.RemoveNode(0);

            Console.WriteLine("Удаляем последний элемент из списка по индексу.");
            linkedList.RemoveNode(linkedList.GetCount() - 1);

            Console.WriteLine($"Удаляем найденный по индексу 5 элемент. Значение {linkedList.GetNode(5).Value}");
            linkedList.RemoveNode(linkedList.GetNode(5));

            Console.WriteLine("Добавляем элемент 25 в конец списка.");
            linkedList.AddNode(25);

            Console.WriteLine("Добавляем элемент 99 после элемента 12.");
            linkedList.AddNodeAfter(linkedList.FindNode(12), 99);

            node = linkedList.FirstNode;

            Console.WriteLine("Вывод элементов списка по порядку от начала.");
            do
            {
                Console.Write($"{node.Value}, ");
                node = node.NextNode;
            } while (node != null);

            Console.WriteLine();
        }

        [Display(Name = "Задание 3", Description = "Сравнение скорости работы класса и структуры.")]
        public static void HomeWork_3_1()
        {
            Random random = new Random();

            int iterations = 50;
            Console.WriteLine($"Количество итераций для получения более точных средних значений: {iterations}. Расчёты запущены.");

            double avgGen100000Class = 0;
            double avgGen100000Struct = 0;
            double avgCalc100000Class = 0;
            double avgCalc100000Struct = 0;
            double avgGen200000Class = 0;
            double avgGen200000Struct = 0;
            double avgCalc200000Class = 0;
            double avgCalc200000Struct = 0;

            for (int i = 0; i < iterations; i++)
            {
                LinesClass linesClass100000 = new LinesClass(random);
                LinesStuct linesStuct100000 = new LinesStuct(random);
                LinesClass linesClass200000 = new LinesClass(random);
                LinesStuct linesStuct200000 = new LinesStuct(random);

                long timeToGen100000Class = linesClass100000.GenerateLines(100000);
                long timeToGen100000struct = linesStuct100000.GenerateLines(100000);
                long timeToCalcDist100000Class = linesClass100000.CalculateLengths();
                long timeToCalcDist100000Struct = linesClass100000.CalculateLengths();

                long timeToGen200000Class = linesClass200000.GenerateLines(200000);
                long timeToGen200000struct = linesStuct200000.GenerateLines(200000);
                long timeToCalcDist200000Class = linesClass200000.CalculateLengths();
                long timeToCalcDist200000Struct = linesClass200000.CalculateLengths();

                avgGen100000Class += timeToGen100000Class;
                avgGen100000Struct += timeToGen100000struct;
                avgCalc100000Class += timeToCalcDist100000Class;
                avgCalc100000Struct += timeToCalcDist100000Struct;
                avgGen200000Class += timeToGen200000Class;
                avgGen200000Struct += timeToGen200000struct;
                avgCalc200000Class += timeToCalcDist200000Class;
                avgCalc200000Struct += timeToCalcDist200000Struct;
            }

            avgGen100000Class /= iterations;
            avgGen100000Struct /= iterations;
            avgCalc100000Class /= iterations;
            avgCalc100000Struct /= iterations;
            avgGen200000Class /= iterations;
            avgGen200000Struct /= iterations;
            avgCalc200000Class /= iterations;
            avgCalc200000Struct /= iterations;

            Console.WriteLine("\nВремя генерации точек:\n");
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9}", "Количество точек", "Время заполнения(класс)", "Время заполнения(структура)", "Отношение");
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9:P2}", 100000, $"{avgGen100000Class}мс", $"{avgGen100000Struct}мс", avgGen100000Class / avgGen100000Struct);
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9:P2}", 200000, $"{avgGen200000Class}мс", $"{avgGen200000Struct}мс", avgGen200000Class / avgGen200000Struct);

            Console.WriteLine("\nВремя подсчёта дистанций:\n");
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9}", "Количество точек", "Время заполнения(класс)", "Время заполнения(структура)", "Отношение");
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9:P2}", 100000, $"{avgCalc100000Class}мс", $"{avgCalc100000Struct}мс", avgCalc100000Class / avgCalc100000Struct);
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9:P2}", 200000, $"{avgCalc200000Class}мс", $"{avgCalc200000Struct}мс", avgCalc200000Class / avgCalc200000Struct);
        }

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
