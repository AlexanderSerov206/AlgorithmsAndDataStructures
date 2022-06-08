using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork7
{
    /// <summary>
    /// Клетка шахматной доски
    /// </summary>
    internal class Cell
    {
        /// <summary>
        /// Состояние клетки
        /// </summary>
        public State State { get; private set; }
        public Cell()
        {
            State = State.Empty;
        }

        /// <summary>
        /// Помечает ячейку как занятую ферзём.
        /// </summary>
        /// <returns>true, если успешно. false, если не успешно.</returns>
        public bool SetOccupied()
        {
            if (State == State.Empty)
            {
                State = State.Occupied;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Помечает ячейку как заблокированную каким-либо ферзём.
        /// </summary>
        /// <returns>true, если успешно. false, если не успешно./returns>
        public bool Lock()
        {
            if (State == State.Empty || State == State.Locked)
            {
                State = State.Locked;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
