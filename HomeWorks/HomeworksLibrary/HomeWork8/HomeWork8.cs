using IHomeworkLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork8
{
    internal class HomeWork8 : IHomework
    {
        [Display(Name = "Задание 8", Description = "Сортировка подсчётом")]
        public static void HomeWork_8()
        {
            Console.WriteLine("Введите целые числа, разделённые пробелом для сортировки.");

            int[] sorted = CountingSort.Sort(GetArrayOfNumbers());

            Console.WriteLine("Отсортированный массив:");
            PrintIntArray(sorted);
        }

        private static int[] GetArrayOfNumbers()
        {
            string answer = Console.ReadLine();

            return ConvertStringToIntsArray(answer);
        }

        private static int[] ConvertStringToIntsArray(string answer)
        {
            string[] separateStrings = answer.Split(' ');
            List<int> numbers = new List<int>();

            foreach (string item in separateStrings)
            {
                if (int.TryParse(item, out int itemAsNumber))
                {
                    numbers.Add(itemAsNumber);
                }
            }

            return numbers.ToArray();
        }

        private static void PrintIntArray(int[] sorted)
        {
            StringBuilder sortedArray = new StringBuilder();

            foreach (int item in sorted)
            {
                sortedArray.Append(item);
                sortedArray.Append(", ");
            }
            sortedArray.Remove(sortedArray.Length - 2, 2);

            Console.WriteLine(sortedArray);
        }
    }
}
