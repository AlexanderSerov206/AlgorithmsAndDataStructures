using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    static class FibonacciCalculator
    {
        /// <summary>
        /// Вычисляет число Фибоначчи рекурсивно. Возможно вычисление как положительных, так и отрицательных значений "n".
        /// </summary>
        /// <param name="n">Порядковый номер числа последовательности Фибоначчи.</param>
        /// <returns></returns>
        public static int GetFibonacciNumberRecursive(int n)
        {
            int fibonacciNumber = 0;

            if (n == 1)
            {
                fibonacciNumber = 1;
            }
            else if (n == -1)
            {
                fibonacciNumber = 1;
            }
            else if (n == 2)
            {
                fibonacciNumber = 1;
            }
            else if (n == -2)
            {
                fibonacciNumber = -1;
            }
            else if (n > 2)
            {
                fibonacciNumber = GetFibonacciNumberRecursive(n - 1) + GetFibonacciNumberRecursive(n - 2);
            }
            else if (n < -2)
            {
                fibonacciNumber = GetFibonacciNumberRecursive(n + 2) - GetFibonacciNumberRecursive(n + 1);
            }

            return fibonacciNumber;
        }

        /// <summary>
        /// Вычисляет число Фибоначчи циклом. Возможно вычисление как положительных, так и отрицательных значений "n".
        /// </summary>
        /// <param name="n">Порядковый номер числа последовательности Фибоначчи.</param>
        /// <returns></returns>
        public static int GetFibonacciNumberNonRecursive(int n)
        {
            int fibonacciNumber = 0;
            int first = 0;
            int second = 1;

            if (Math.Abs(n) == 1) fibonacciNumber = second;

            for (int i = 0; i < Math.Abs(n) - 1; i++)
            {
                fibonacciNumber = first + second;
                first = second;
                second = fibonacciNumber;
            }

            if (n < 0 && n % 2 == 0) // Если порядковый номер отрицательный и чётный, то знак у числа последовательности будет отрицательный.
            {
                return Math.Sign(n) * fibonacciNumber;
            }
            else
            {
                return fibonacciNumber;
            }
        }
    }
}
