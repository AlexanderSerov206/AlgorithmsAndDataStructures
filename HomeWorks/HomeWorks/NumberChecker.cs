using System;

namespace HomeWorks
{
    static class NumberChecker
    {
        public static bool IsNumberSimple(int number)
        {
            int d = 0;
            int i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                    i++;
                }
                else
                {
                    i++;
                }
            }

            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsNumberSimple_11_True()
        {
            return IsNumberSimple(11);
        }

        public static bool IsNumberSimple_10_False()
        {
            return IsNumberSimple(10);
        }
    }
}
