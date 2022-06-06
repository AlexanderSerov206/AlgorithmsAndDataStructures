using HomeworksLibrary.HomeWork2;
using IHomeworkLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork2
{
    public class Homework2 : IHomework
    {
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

    }
}
