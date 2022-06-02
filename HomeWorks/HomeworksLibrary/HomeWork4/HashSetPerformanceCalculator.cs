using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork4
{
    internal class HashSetPerformanceCalculator
    {
        public static TimeSpan HashSetFillPerformance(Random random, int count, HashSet<string> stringHashSet)
        {
            Stopwatch stopwatchHashSet = new Stopwatch();

            stopwatchHashSet.Start();
            for (int i = 0; i < count; i++)
            {
                stringHashSet.Add(RandomStringGenerator.GenerateWord(random, 10));
            }
            stopwatchHashSet.Stop();

            return stopwatchHashSet.Elapsed;
        }
        public static TimeSpan SearchRandomWordHashSet(Random random, HashSet<string> stringHashSet)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            stringHashSet.Contains(RandomStringGenerator.GenerateWord(random, 10));
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}
