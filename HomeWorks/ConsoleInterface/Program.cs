using IHomeworkLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HomeworksLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunSelectedHomework(GetMethods());
        }

        /// <summary>
        /// Возвращает список методов, которые содержатся в библиотеке HomeworksLibrary.dll и реализуют интерфейс IHomework
        /// </summary>
        /// <returns></returns>
        private static MethodInfo[] GetMethods()
        {
            Assembly assembly = Assembly.LoadFrom("HomeworksLibrary.dll");
            List<Type> types = assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(IHomework))).ToList();

            MethodInfo[] methods = types.SelectMany(x => x.GetMethods().Where(y => y.Module.ToString() == "HomeworksLibrary.dll")).OrderBy(x => x.Name).ToArray();
            return methods;
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
                List<CustomAttributeNamedArgument> methodAttributes = method.CustomAttributes.First().NamedArguments.ToList();
                string methodName = methodAttributes[0].TypedValue.ToString().Replace("\"", "");
                string methodDescription = methodAttributes[1].TypedValue.ToString().Replace("\"", "");

                Console.WriteLine($"Введите {Array.IndexOf(methods, method) + 1}, чтобы запустить {methodName}. {methodDescription}");
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
                PrintMethodsInfo(methods);

                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= methods.Length)
                {
                    Console.WriteLine($"\nЗапуск домашнего задания {methods[index - 1].Name}...\n");

                    PrintDelimiter("Начало работы метода");

                    methods[index - 1].Invoke(null, null);

                    PrintDelimiter("Конец работы метода");
                }
                else
                {
                    Console.WriteLine("Введено некорректное значение, проверьте ввод.");
                }
            }
        }

        /// <summary>
        /// Печатает разделитель в консоль для более простого восприятия начала и окончания работы метода.
        /// </summary>
        /// <param name="message">Сообщение для вывода в консоль в полосе разделителя.</param>
        private static void PrintDelimiter(string message)
        {
            StringBuilder delimiter = new StringBuilder();
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                delimiter.Append("═");
            }

            Console.WriteLine(delimiter);
            Console.CursorLeft = Console.BufferWidth / 2 - message.Length / 2;
            Console.WriteLine(message);
            Console.WriteLine(delimiter);
        }
    }
}
