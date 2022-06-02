using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork3
{
    internal class LinesStuct
    {
        List<LineStruct> Lines { get; set; }
        Random Random { get; set; }

        public LinesStuct(Random random)
        {
            Lines = new List<LineStruct>();
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
                Lines.Add(new LineStruct(Random));
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

            foreach (LineStruct line in Lines)
            {
                line.CalculateLength();
            }

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}
