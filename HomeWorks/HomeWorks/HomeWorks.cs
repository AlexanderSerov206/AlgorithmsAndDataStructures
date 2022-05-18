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

            while (true)
            {
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
        }
        public static void HomeWork_1_3()
        {
            while (true)
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
        }
    }
}
