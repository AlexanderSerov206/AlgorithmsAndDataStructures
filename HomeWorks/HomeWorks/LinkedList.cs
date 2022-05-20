using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class LinkedList : ILinkedList
    {
        public Node FirstNode { get; private set; }
        public Node LastNode { get; private set; }
        public LinkedList()
        {

        }

        /// <summary>
        /// Конструктор, позволяющий инициализировать экземпляр списка с массивом значений.
        /// </summary>
        /// <param name="array">Массив, из которого будет построен двусвязный список</param>
        public LinkedList(int[] array)
        {
            foreach (int value in array)
            {
                AddNode(value);
            }
        }

        /// <summary>
        /// Добавить новое значение в конец списка.
        /// </summary>
        /// <param name="value">Значение для добавления.</param>
        public void AddNode(int value)
        {
            if (FirstNode == null) // Если первая нода пуста, значит список пустой, добавляем ноду без ссылок
            {
                FirstNode = new Node(value);
            }
            else if (LastNode == null) // Если последняя нода пуста, но первая при этом не пуста, то добавляем значение в качестве последней ноды и добавляем ссылки в первую и последнюю ноды
            {
                LastNode = new Node(value, FirstNode);
                FirstNode.NextNode = LastNode;
                LastNode.PrevNode = FirstNode;
            }
            else // В остальных случаях, создаём новый экземпляр ноды, и добавляем ссылки.
            {
                Node newLastNode = new Node(value, LastNode);
                LastNode.NextNode = newLastNode;
                LastNode = newLastNode;
            }
        }
        
        /// <summary>
        /// Добавить новое значение после указанного узла.
        /// </summary>
        /// <param name="node">Узел, после которого требуется добавить новое значение.</param>
        /// <param name="value">Значение для добавления.</param>
        public void AddNodeAfter(Node node, int value)
        {
            if (node.PrevNode == null && node.NextNode == null) // Если в параметры передан единственный элемент списка, то вызываем реализацию AddNode()
            {
                AddNode(value);
            }
            else if (node.NextNode == null) // Если методу передан последний элемент списка, то вызываем реализацию AddNode()
            {
                AddNode(value);
            }
            else // В остальных случаях создаём новый экземпляр ноды и переопределяем ссылки у предыдущего и последующего
            {
                Node newNode = new Node(value, node, node.NextNode);
                node.NextNode.PrevNode = newNode;
                node.NextNode = newNode;
            }
        }
        
        /// <summary>
        /// Поиск узла в списке по значению. Поиск происходит от первого элемента к последнему.
        /// </summary>
        /// <param name="searchValue">Значение для поиска.</param>
        /// <returns>Возвращает первый узел, значение которого совпадает с искомым значением.</returns>
        public Node FindNode(int searchValue)
        {
            int count = GetCount();

            Node node = FirstNode;

            for (int i = 0; i < count; i++)
            {
                if (node.Value == searchValue)
                {
                    return node;
                }
                else
                {
                    node = node.NextNode;
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">Искомый индекс.</param>
        /// <returns>Возвращает узел с указанным индексом.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Node GetNode(int index)
        {
            if (index >= GetCount())
            {
                throw new IndexOutOfRangeException("Указанный индекс находится за пределами количества элементов в списке.");
            }
            else
            {
                Node node = FirstNode;

                for (int i = 0; i < index; i++)
                {
                    node = node.NextNode;
                }

                return node;
            }
        }
        
        /// <summary>
        /// Осуществляет бинарный поиск индекса указанного узла.
        /// </summary>
        /// <param name="node">Узел, индекс которого требуется найти.</param>
        /// <returns>Индекс узла.</returns>
        public int GetNodeIndex(Node node)
        {
            int index = -1;
            int min = 0;
            int max = GetCount();
            Node fromStart = FirstNode;
            Node fromEnd = LastNode;

            while (min <= max)
            {
                if (fromStart == node)
                {
                    index = min;
                    return index;
                }
                else if (fromEnd == node)
                {
                    index = max;
                    return index;
                }
                else
                {
                    min++;
                    fromStart = fromStart.NextNode;
                    max--;
                    fromEnd = fromEnd.PrevNode;
                }
            }

            return index;
        }

        /// <summary>
        /// Подсчитать количество элементов в двусвязном списке.
        /// </summary>
        /// <returns>Количество элементов.</returns>
        public int GetCount()
        {
            Node node = FirstNode;
            int count = 0;

            while (node != null)
            {
                count++;
                node = node.NextNode;
            }
            return count;
        }

        /// <summary>
        /// Удаление элемента из списка по его индексу.
        /// </summary>
        /// <param name="index">Индекс узла, который требуется удалить.</param>
        public void RemoveNode(int index)
        {
            Node node = GetNode(index);

            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = node.NextNode;
            }
            else
            {
                FirstNode = node.NextNode;
            }

            if (node.NextNode != null)
            {
                node.NextNode.PrevNode = node.PrevNode;
            }
            else
            {
                LastNode = node.PrevNode;
            }

            node.Dispose();
        }

        /// <summary>
        /// Удаление элемента из списка.
        /// </summary>
        /// <param name="node">Элемент, который требуется удалить.</param>
        public void RemoveNode(Node node)
        {
            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = node.NextNode;
            }
            else
            {
                FirstNode = node.NextNode;
            }

            if (node.NextNode != null)
            {
                node.NextNode.PrevNode = node.PrevNode;
            }
            else
            {
                LastNode = node.PrevNode;
            }

            node.Dispose();
        }
    }
}
