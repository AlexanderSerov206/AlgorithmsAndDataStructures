using System;

namespace HomeWorks
{
    /// <summary>
    /// Класс для размещения методов, которые будут запускать проверку домашних заданий.
    /// </summary>
    static class HomeWorks
    {
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
    }
}
