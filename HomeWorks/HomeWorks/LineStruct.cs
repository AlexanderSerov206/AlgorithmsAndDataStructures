using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class LineStruct
    {
        public PointStructDouble PointOne { get; private set; }
        public PointStructDouble PointTwo { get; private set; }

        /// <summary>
        /// Конструктор, позволяющий генерировать отрезок из ранее созданных точек.
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        public LineStruct(PointStructDouble pointOne, PointStructDouble pointTwo)   
        {
            PointOne = pointOne;
            PointTwo = pointTwo;
        }

        /// <summary>
        /// Конструктор, генерирующий отрезок со случайными координатами точек.
        /// </summary>
        /// <param name="random"></param>
        public LineStruct(Random random)
        {
            PointOne = new PointStructDouble() { X = random.NextDouble(), Y = random.NextDouble() };
            PointTwo = new PointStructDouble() { X = random.NextDouble(), Y = random.NextDouble() };
        }

        /// <summary>
        /// Рассчитать длину отрезка.
        /// </summary>
        /// <returns></returns>
        public double CalculateLength()
        {
            double x = PointOne.X - PointTwo.X;
            double y = PointOne.Y - PointTwo.Y;

            return Math.Sqrt((x * x) + (y * y));
        }
    }
}
