using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork7
{
    internal class Board
    {
        public int Size { get; private set; }
        /// <summary>
        /// Массив клеток шахматной доски
        /// </summary>
        public Cell[,] Cells { get; set; }

        /// <summary>
        /// Количество ферзей на доске
        /// </summary>
        public int QueensCount { get; private set; }

        /// <summary>
        /// Количество свободных клеток
        /// </summary>
        public int FreeCellsCount { get; set; }

        /// <summary>
        /// Конструктор, создающий доску 8х8
        /// </summary>
        public Board(int size)
        {
            Size = size;
            Cells = new Cell[Size, Size];
            FreeCellsCount = Size * Size;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }
        }

        /// <summary>
        /// Устанавливает ферзя на доску по заданным координатам. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Возвращает true, если ферзь установлен. Возвращает false, если указанная клетка заблокирована или занята другим ферзём.</returns>
        public bool SetQueen(int x, int y)
        {
            if (!Cells[y, x].SetOccupied()) //Совершает попытку установить ферзя на заданную ячейку. Если попытка успешная, то продолжает выполнение метода и блокирует ячейки, которые ферзь установленный бьёт. Иначе - останавливает выполнение и возвращает false.
                return false;

            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                if (Cells[y, x] != Cells[i, x] && !Cells[i, x].Lock())
                    return false;

                if (Cells[y, x] != Cells[y, i] && !Cells[y, i].Lock())
                    return false;

                if (i != 0)
                {
                    if (y + i < Cells.GetLength(0) && x + i < Cells.GetLength(1) && !Cells[y + i, x + i].Lock())
                        return false;

                    if (y + i < Cells.GetLength(0) && x - i >= 0 && !Cells[y + i, x - i].Lock())
                        return false;

                    if (y - i >= 0 && x + i < Cells.GetLength(1) && !Cells[y - i, x + i].Lock())
                        return false;

                    if (y - i >= 0 && x - i >= 0 && !Cells[y - i, x - i].Lock())
                        return false;
                }
            }

            CountFreeCells();
            QueensCount++;
            return true;
        }

        /// <summary>
        /// Подсчитывает текущее количество пустых клеток на доске.
        /// </summary>
        public void CountFreeCells()
        {
            FreeCellsCount = 0;

            foreach (Cell cell in Cells)
            {
                if (cell.State == State.Empty)
                {
                    FreeCellsCount++;
                }
            }
        }

        /// <summary>
        /// Возвращает копию текущей доски.
        /// </summary>
        /// <returns></returns>
        public Board Copy()
        {
            Board copiedBoard = new Board(Size);

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Cells[i, j].State == State.Occupied)
                    {
                        copiedBoard.Cells[i, j].SetOccupied();
                        copiedBoard.QueensCount++;
                    }
                    else if (Cells[i, j].State == State.Locked)
                    {
                        copiedBoard.Cells[i, j].Lock();
                    }
                }
            }

            copiedBoard.CountFreeCells();
            return copiedBoard;
        }

        /// <summary>
        /// Возвращает список координат пустых ячеек на заданном ряду.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public List<int> GetEmptyCellsOnRow(int row)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < Size; i++)
            {
                if (Cells[row, i].State == State.Empty)
                {
                    numbers.Add(i);
                }
            }

            return numbers;
        }
    }
}
