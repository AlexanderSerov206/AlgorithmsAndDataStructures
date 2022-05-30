using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks.HomeWork2
{
    /// <summary>
    /// Узел двусвязного списка. Содержит информацию о значении и ссылки на предыдущий и последующий элементы, если они есть.
    /// </summary>
    public class Node : IDisposable
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Значение узла</param>
        /// <param name="prevNode">Предыдущий узел</param>
        /// <param name="nextNode">Следующий узел</param>
        public Node(int value, Node prevNode, Node nextNode)
        {
            Value = value;
            NextNode = nextNode;
            PrevNode = prevNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Значение узла</param>
        /// <param name="prevNode">Предыдущий узел</param>
        public Node(int value, Node prevNode)
        {
            Value = value;
            PrevNode = prevNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Значение узла</param>
        public Node(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Высвобождение ссылок на другие элементы списка при удалении.
        /// </summary>
        public void Dispose()
        {
            NextNode = null;
            PrevNode = null;
        }
    }
}
