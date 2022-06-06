using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork4
{
    public static class RandomStringGenerator
    {
        /// <summary>
        /// Генерирует случайную строку.
        /// </summary>
        /// <param name="random"></param>
        /// <param name="numberOfLetters">Необходимое количество букв в слове.</param>
        /// <returns></returns>
        public static string GenerateWord(Random random, int numberOfLetters)
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            string word = "";
            for (int j = 1; j <= numberOfLetters; j++)
            {
                int letter_num = random.Next(0, letters.Length - 1);

                word += letters[letter_num];
            }
            return word;
        }
    }
}
