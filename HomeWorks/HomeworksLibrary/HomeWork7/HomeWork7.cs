using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHomeworkLibrary;

namespace HomeworksLibrary.HomeWork7
{
    internal class HomeWork7 : IHomework
    {
        [Display(Name = "Задание 7", Description = "Решение задачи о N ферзях")]
        public static void HomeWork_7()
        {
            bool continueExecution = true;
            while (continueExecution)
            {
                Console.WriteLine("Введите размерность доски. Вычисление размерностей больше 12 может занять продолжительное время. \nВведите \"END\" для возвращения в меню выбора ДЗ.");
                string inputString = Console.ReadLine();

                if (int.TryParse(inputString, out int size))
                {
                    List<Board> boards = GetAllPossibleBoards(size);

                    Console.WriteLine($"Досок с {size} ферзями: {boards.Count}");

                    while (true)
                    {
                        Console.WriteLine("Напечатать все результаты? Y\\N");
                        string inputPrint = Console.ReadLine();

                        if (inputPrint.ToUpper() == "Y")
                        {
                            PrintBoards(boards);
                            break;
                        }
                        else if (inputPrint.ToUpper() == "N")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введено некорректное значение.");
                        }
                    }
                }
                else if (inputString.ToUpper() == "END")
                {
                    continueExecution = false;
                }
                else
                {
                    Console.WriteLine("Введено некорректное значение.");
                }
            }
        }

        /// <summary>
        /// Печатает в консоль все доски из списка.
        /// </summary>
        /// <param name="boards"></param>
        private static void PrintBoards(List<Board> boards)
        {
            foreach (Board board in boards)
            {
                PrintBoard(board);
            }
        }

        /// <summary>
        /// Запускает поиск всех возможных вариантов размещения ферзей перебором, изменяя расположение первого ферзя начиная с первого ряда и первого столбца и заканчивая последним рядом последним столбцом.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static List<Board> GetAllPossibleBoards(int size)
        {
            List<Board> boards = new List<Board>();

            int x = 0;
            int y = 0;

            while (y != size)
            {
                Board board = new Board(size);

                CalculateBoards(boards, board, x, y);

                if (x < board.Cells.GetLength(1) - 1)
                {
                    x++;
                }
                else
                {
                    x = 0;
                    y++;
                }
            }

            return boards;
        }

        /// <summary>
        /// Рекурсивно расчитывает возможные расстановки начиная с заданной стартовой доски, добавляет успешные в список.
        /// </summary>
        /// <param name="successfulBoards">Список для добавления успешных досок.</param>
        /// <param name="board">Доска, с которой будет проводиться итерация.</param>
        /// <param name="startingX">Координата X ячейки, с которой начинается перебор.</param>
        /// <param name="startingY">Координата Y ячейки, с которой начинается перебор.</param>
        private static void CalculateBoards(List<Board> successfulBoards, Board board, int startingX, int startingY)
        {
            Board tempBoard = board.Copy(); // создаёт временную копию доски для перебора вариантов установки ферзей.

            if (tempBoard.QueensCount == 0) // если входная доска пустая, то устанавливает ферзя на заданные координаты без проверок.
            {
                tempBoard.SetQueen(startingX, startingY);
                CalculateBoards(successfulBoards, tempBoard, startingX, startingY + 1);
            }

            List<int> emptyNumbers = new List<int>();

            if (startingY < tempBoard.Size)
            {
                emptyNumbers = tempBoard.GetEmptyCellsOnRow(startingY); // получает список пустых ячеек на заданном ряду.
            }

            foreach (int emptyCellNumber in emptyNumbers) // проходит по всем пустым ячейкам ряда и ищет возможные варианты установки ферзей на него.
            {
                tempBoard = board.Copy();

                // если номер ряда меньше размерности и установка ферзя завершилась успешно, рекурсивно запускает поиск новых вариантов с установленным ферзём.
                if (startingY < board.Size && tempBoard.SetQueen(emptyCellNumber, startingY))
                {
                    CalculateBoards(successfulBoards, tempBoard, startingX, startingY + 1);
                }

                // если количество ферзей на доске соответствует заданной размерности, добавляем доску в список успешных решений.
                if (tempBoard.QueensCount == tempBoard.Size)
                {
                    successfulBoards.Add(tempBoard);
                }
            }
        }

        /// <summary>
        /// Печатает шахматную доску в консоль.
        /// </summary>
        /// <param name="board"></param>
        private static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Cells.GetLength(0); i++)
            {
                if (i == 0)
                {
                    for (int k = 0; k < board.Cells.GetLength(1); k++) // Печатает верхнюю границу доски
                    {
                        if (k == 0)
                        {
                            Console.Write("┌───");
                        }
                        else if (k == board.Cells.GetLength(1) - 1)
                        {
                            Console.Write("┬───┐");
                        }
                        else
                        {
                            Console.Write("┬───");
                        }
                    }
                    Console.WriteLine();
                }

                for (int j = 0; j < board.Cells.GetLength(1); j++) // Наполняет строку значениями
                {

                    Console.Write("│");

                    switch (board.Cells[i, j].State)
                    {
                        case State.Empty:
                            Console.Write("   ");
                            continue;
                        case State.Occupied:
                            Console.Write(" ╬ ");
                            continue;
                        case State.Locked:
                            Console.Write(" x ");
                            continue;
                    }
                }
                Console.Write("│");


                Console.WriteLine();

                if (i < board.Cells.GetLength(0) - 1)
                {
                    for (int k = 0; k < board.Cells.GetLength(1); k++) // Печатает промежуточные границы, если строка не первая и не последняя
                    {
                        if (k == 0)
                        {
                            Console.Write("├───");
                        }
                        else if (k == board.Cells.GetLength(1) - 1)
                        {
                            Console.Write("┼───┤");
                        }
                        else
                        {
                            Console.Write("┼───");
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < board.Cells.GetLength(1); k++) // Печатает нижнюю границу доски
                    {
                        if (k == 0)
                        {
                            Console.Write("└───");
                        }
                        else if (k == board.Cells.GetLength(1) - 1)
                        {
                            Console.Write("┴───┘");
                        }
                        else
                        {
                            Console.Write("┴───");
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
