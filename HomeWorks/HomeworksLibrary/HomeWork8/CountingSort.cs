using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork8
{
    static class CountingSort
    {
        public static int[] Sort(int[] inArray)
        {
            int min = inArray.Min();
            int max = inArray.Max();
            int count = max - min + 1;

            int[] countNumbers = new int[count];
            int[] outArray = new int[inArray.Length];

            for (int i = 0; i < inArray.Length; i++)
            {
                countNumbers[inArray[i] - min]++;
            }

            int iterator = 0;

            for (int i = min; i <= max; i++)
            {
                while (countNumbers[i - min]-- > 0)
                {
                    outArray[iterator] = i;
                    iterator++;
                }
            }

            return outArray;
        }
    }
}
