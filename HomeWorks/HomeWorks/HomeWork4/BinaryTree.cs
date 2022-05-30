using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks.HomeWork4
{
    public class BinaryTree<T> where T : IComparable
    {    
        private BinaryTree<T> branchRight;
        private BinaryTree<T> branchLeft;
        private T _value;

        /// <summary>
        /// Значение текущей ветви.
        /// </summary>
        public T Value { get => _value; private set { _value = value; IsEmpty = false; } }

        /// <summary>
        /// Корень дерева. Элемент, у которого нет родителя.
        /// </summary>
        public BinaryTree<T> Root { get; private set; }

        /// <summary>
        /// Родительская ветвь текущего дерева.
        /// </summary>
        public BinaryTree<T> Parent { get; private set; }

        /// <summary>
        /// Левая ветвь.
        /// </summary>
        public BinaryTree<T> BranchLeft { get => branchLeft; private set { branchLeft = value; OnBranchAdded(); } }

        /// <summary>
        /// Правая ветвь.
        /// </summary>
        public BinaryTree<T> BranchRight { get => branchRight; private set { branchRight = value; OnBranchAdded(); } }

        /// <summary>
        /// Свойство, показывающее является ли значение пустым.
        /// </summary>
        private bool IsEmpty { get; set; } = true;

        /// <summary>
        /// Является ли текущая ветвь последней.
        /// </summary>
        private bool IsLeaf { get; set; } = true;

        /// <summary>
        /// Количество дочерних элементов у текущей ветви.
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Глубина текущей ветви относительно корня. 1 - корень.
        /// </summary>
        public int Depth { get; private set; } = 1;

        /// <summary>
        /// При инициализации добавляет элемент "корень"
        /// </summary>
        /// <param name="value"></param>
        public BinaryTree(T value)
        {
            Value = value;
            Root = SetRoot();
            IncrementCount();
            CalculateDepth();
        }

        /// <summary>
        /// Для использования внутри класса, с указанием родительской ветви.
        /// </summary>
        /// <param name="parent"></param>
        private BinaryTree(BinaryTree<T> parent)
        {
            Parent = parent;
            Root = SetRoot();
            IncrementCount();
            CalculateDepth();
        }

        /// <summary>
        /// Метод, изменяющий значение свойства IsLeaf
        /// </summary>
        private void OnBranchAdded()
        {
            if (BranchRight != null || BranchLeft != null)
            {
                IsLeaf = false;
            }
            else if (BranchRight == null && BranchLeft == null)
            {
                IsLeaf = true;
            }
        }

        /// <summary>
        /// Добавление значения в дерево.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(T value)
        {
            bool result = false;

            if (Search(value) == null)
            {
                result = true;

                if (IsEmpty)
                {
                    Value = value;
                }
                else
                {
                    if (BranchLeft == null)
                    {
                        BranchLeft = new BinaryTree<T>(this);
                        BranchLeft.Add(value);
                    }
                    else if (BranchRight == null)
                    {
                        BranchRight = new BinaryTree<T>(this);
                        BranchRight.Add(value);
                    }
                    else if (BranchRight.Count < BranchLeft.Count)
                    {
                        BranchRight.Add(value);
                    }
                    else
                    {
                        BranchLeft.Add(value);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Удаление значения из дерева. Удалить возможно только элемент, у которого нет дочерних.
        /// </summary>
        /// <returns>true - успешно, false - не успешно.</returns>
        public bool Remove()
        {
            if (IsLeaf && this != Root)
            {
                if (Parent.BranchLeft == this)
                {
                    Parent.BranchLeft = null;
                    return true;
                }
                else if (Parent.BranchRight == this)
                {
                    Parent.BranchRight = null;
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Поиск элемента в дереве начиная с корня.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public BinaryTree<T> Search(T value)
        {
            return Search(value, Root);
        }

        /// <summary>
        /// Поиск элемента в дереве начиная с заданной ветви.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startingBranch"></param>
        /// <returns></returns>
        public BinaryTree<T> Search(T value, BinaryTree<T> startingBranch)
        {
            if (startingBranch == null)
            {
                return null;
            }
            else if (value.CompareTo(startingBranch.Value) == 0)
            {
                return startingBranch;
            }            
            else
            {
                BinaryTree<T> result = Search(value, startingBranch.BranchLeft);

                if (result == null)
                {
                    result = Search(value, startingBranch.BranchRight);
                }

                return result;
            }
        }

        /// <summary>
        /// Расчёт глубины текущей ветви относительно корня. 1 - корень.
        /// </summary>
        private void CalculateDepth()
        {
            BinaryTree<T> parent = Parent;

            while (parent != null)
            {
                Depth++;
                parent = parent.Parent;
            }
        }

        /// <summary>
        /// Возвращает высоту дерева, начинай с текущей ветви.
        /// </summary>
        /// <returns></returns>
        public int GetHeight()
        {
            int maximumHeight = 0;
            CalculateHeight(this, 1, ref maximumHeight);
            return maximumHeight;
        }

        /// <summary>
        /// Рекурсивный метод для расчёта высоты дерева.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="height"></param>
        /// <param name="maximumHeight"></param>
        private void CalculateHeight(BinaryTree<T> tree, int height, ref int maximumHeight)
        {
            if (height > maximumHeight)
            {
                maximumHeight = height;
            }

            if (tree.BranchLeft != null)
            {
                CalculateHeight(tree.BranchLeft, height + 1, ref maximumHeight);
            }

            if (tree.BranchRight != null)
            {
                CalculateHeight(tree.BranchRight, height + 1, ref maximumHeight);
            }
        }

        /// <summary>
        /// Устанавливает значение поля Root у дочерних ветвей.
        /// </summary>
        /// <returns></returns>
        private BinaryTree<T> SetRoot()
        {
            BinaryTree<T> root = this;

            if (Parent != null)
            {
                root = Parent.SetRoot();
            }

            return root;
        }

        /// <summary>
        /// Увеличивает счётчик Count при создании новых ветвей.
        /// </summary>
        private void IncrementCount()
        {
            if (Parent != null)
            {
                Parent.IncrementCount();
                Count++;
            }
            else if (Parent == null)
            {
                Count++;
            }
        }
    }
}
