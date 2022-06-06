using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork4
{
    internal class ArrayPerformanceCalculator
    {
        public static TimeSpan ArrayFillPerformance(Random random, int count, string[] stringArray)
        {
            Stopwatch stopwatchArray = new Stopwatch();

            stopwatchArray.Start();
            for (int i = 0; i < count; i++)
            {
                stringArray[i] = RandomStringGenerator.GenerateWord(random, 10);
            }
            stopwatchArray.Stop();

            return stopwatchArray.Elapsed;
        }
        public static TimeSpan SearchRandomWordArray(Random random, string[] stringArray)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            stringArray.Contains(RandomStringGenerator.GenerateWord(random, 10));
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}
