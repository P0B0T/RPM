using LibMatrix;
using System;

namespace Lib_11
{
    public static class ExtensionMatrix
    {
        /// <summary>
        /// Заполнение двумерного массива из класса Matrix
        /// </summary>
        /// <param name="numbers">Двумерный массив из класса Matrix</param>
        /// <param name="rows">Значение строк которые мы получаем от пользователя</param>
        /// <param name="column">Значение столбцов которые мы получаем от пользователя</param>
        /// <param name="minValue">Минимальное значение для случайного числа</param>
        /// <param name="maxValue">Максимальное значение для случайного числа</param>
        public static void FillMatrix(this Matrix<int> numbers, int rows, int column, int minValue = 0, int maxValue = 100)
        {
            int[,] array = new int[rows, column];
            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array[i, j] = rnd.Next(minValue, maxValue);
                }
            }
            numbers.Add(array);
        }
        /// <summary>
        /// Находим разницу чисел
        /// </summary>
        /// <param name="numbers">Двумерный массив из класса Matrix</param>
        /// <returns></returns>
        public static int Difference(this Matrix<int> numbers)
        {
            int razn = 0;
            for (int i = 0; i < numbers.Rows; i++)
            {
                for (int j = 0; j < numbers.Columns; j++)
                {
                    razn -= numbers[i, j];
                }
            }
            return razn;
        }
    }
}
