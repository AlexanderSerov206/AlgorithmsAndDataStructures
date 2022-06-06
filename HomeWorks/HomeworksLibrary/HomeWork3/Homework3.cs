using HomeworksLibrary.HomeWork3;
using IHomeworkLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworksLibrary.HomeWork3
{
    public class Homework3 : IHomework
    {
        [Display(Name = "Задание 3", Description = "Сравнение скорости работы класса и структуры.")]
        public static void HomeWork_3_1()
        {
            Random random = new Random();

            int iterations = 50;
            Console.WriteLine($"Количество итераций для получения более точных средних значений: {iterations}. Расчёты запущены.");

            double avgGen100000Class = 0;
            double avgGen100000Struct = 0;
            double avgCalc100000Class = 0;
            double avgCalc100000Struct = 0;
            double avgGen200000Class = 0;
            double avgGen200000Struct = 0;
            double avgCalc200000Class = 0;
            double avgCalc200000Struct = 0;

            for (int i = 0; i < iterations; i++)
            {
                LinesClass linesClass100000 = new LinesClass(random);
                LinesStuct linesStuct100000 = new LinesStuct(random);
                LinesClass linesClass200000 = new LinesClass(random);
                LinesStuct linesStuct200000 = new LinesStuct(random);

                long timeToGen100000Class = linesClass100000.GenerateLines(100000);
                long timeToGen100000struct = linesStuct100000.GenerateLines(100000);
                long timeToCalcDist100000Class = linesClass100000.CalculateLengths();
                long timeToCalcDist100000Struct = linesClass100000.CalculateLengths();

                long timeToGen200000Class = linesClass200000.GenerateLines(200000);
                long timeToGen200000struct = linesStuct200000.GenerateLines(200000);
                long timeToCalcDist200000Class = linesClass200000.CalculateLengths();
                long timeToCalcDist200000Struct = linesClass200000.CalculateLengths();

                avgGen100000Class += timeToGen100000Class;
                avgGen100000Struct += timeToGen100000struct;
                avgCalc100000Class += timeToCalcDist100000Class;
                avgCalc100000Struct += timeToCalcDist100000Struct;
                avgGen200000Class += timeToGen200000Class;
                avgGen200000Struct += timeToGen200000struct;
                avgCalc200000Class += timeToCalcDist200000Class;
                avgCalc200000Struct += timeToCalcDist200000Struct;
            }

            avgGen100000Class /= iterations;
            avgGen100000Struct /= iterations;
            avgCalc100000Class /= iterations;
            avgCalc100000Struct /= iterations;
            avgGen200000Class /= iterations;
            avgGen200000Struct /= iterations;
            avgCalc200000Class /= iterations;
            avgCalc200000Struct /= iterations;

            Console.WriteLine("\nВремя генерации точек:\n");
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9}", "Количество точек", "Время заполнения(класс)", "Время заполнения(структура)", "Отношение");
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9:P2}", 100000, $"{avgGen100000Class}мс", $"{avgGen100000Struct}мс", avgGen100000Class / avgGen100000Struct);
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9:P2}", 200000, $"{avgGen200000Class}мс", $"{avgGen200000Struct}мс", avgGen200000Class / avgGen200000Struct);

            Console.WriteLine("\nВремя подсчёта дистанций:\n");
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9}", "Количество точек", "Время заполнения(класс)", "Время заполнения(структура)", "Отношение");
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9:P2}", 100000, $"{avgCalc100000Class}мс", $"{avgCalc100000Struct}мс", avgCalc100000Class / avgCalc100000Struct);
            Console.WriteLine("{0, -16} ║ {1, -23} ║ {2, -27} ║ {3, -9:P2}", 200000, $"{avgCalc200000Class}мс", $"{avgCalc200000Struct}мс", avgCalc200000Class / avgCalc200000Struct);
        }
    }
}
