using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HomeWorks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MethodInfo[] methods = typeof(HomeWorks).GetMethods().Where(x => x.Module.Name.Equals("HomeWorks.dll")).ToArray(); // Выбирает все методы, которые объявлены в классе HomeWorks

            PrintMethodsInfo(methods);

            RunSelectedHomework(methods);
        }

        /// <summary>
        /// Выводит в консоль все методы из массива.
        /// </summary>
        /// <param name="methods"></param>
        private static void PrintMethodsInfo(MethodInfo[] methods)
        {
            Console.WriteLine("Домашние задания, доступные для запуска:");

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine($"Введите {Array.IndexOf(methods, method) + 1}, чтобы запустить задание {method.Name}");
            }
        }

        /// <summary>
        /// Запускает выбранный по индексу метод.
        /// </summary>
        /// <param name="methods"></param>
        private static void RunSelectedHomework(MethodInfo[] methods)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= methods.Length)
                {
                    Console.WriteLine($"\nЗапуск домашнего задания {methods[index - 1].Name}...\n");

                    methods[index - 1].Invoke(null, null);
                }
                else
                {
                    Console.WriteLine("Введено некорректное значение, проверьте ввод.");
                }
            }
        }
    }
}
