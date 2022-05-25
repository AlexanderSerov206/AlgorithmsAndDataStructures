using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class LinesClass
    {
        List<LineClass> Lines { get; set; }
        Random Random { get; set; }

        public LinesClass(Random random)
        {
            Lines = new List<LineClass>();
            Random = random;
        }

        /// <summary>
        /// Генерация заданного кол-ва линий со случайными координатами точек.
        /// </summary>
        /// <param name="count">Количество линий для генерации.</param>
        /// <returns>Время, затраченное на генерацию.</returns>
        public long GenerateLines(int count)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            for (int i = 0; i < count; i++)
            {
                Lines.Add(new LineClass(Random));
            }

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Подсчёт длин всех линий, которые содержатся в списке класса.
        /// </summary>
        /// <returns>Время, затраченное на расчёты.</returns>
        public long CalculateLengths()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            foreach (LineClass line in Lines)
            {
                line.CalculateLength();
            }

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}
