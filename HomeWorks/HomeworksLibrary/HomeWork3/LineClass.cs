using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork3
{
    internal class LineClass
    {
        public PointClassDouble PointOne { get; private set; }
        public PointClassDouble PointTwo { get; private set; }

        /// <summary>
        /// Конструктор, позволяющий генерировать отрезок из ранее созданных точек.
        /// </summary>
        /// <param name="pointOne"></param>
        /// <param name="pointTwo"></param>
        public LineClass(PointClassDouble pointOne, PointClassDouble pointTwo)
        {
            PointOne = pointOne;
            PointTwo = pointTwo;
        }

        /// <summary>
        /// Конструктор, генерирующий отрезок со случайными координатами точек.
        /// </summary>
        /// <param name="random"></param>
        public LineClass(Random random)
        {
            PointOne = new PointClassDouble() { X = random.NextDouble(), Y = random.NextDouble() };
            PointTwo = new PointClassDouble() { X = random.NextDouble(), Y = random.NextDouble() };
        }

        /// <summary>
        /// Рассчитать длину отрезка.
        /// </summary>
        /// <returns></returns>
        public double CalculateLength()
        {
            double x = PointOne.X - PointTwo.X;
            double y = PointOne.Y - PointTwo.Y;

            return Math.Sqrt(x * x + y * y);
        }
    }
}
