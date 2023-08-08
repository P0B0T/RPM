using System;

namespace Lib_11
{
    public static class MathString
    {
        /// <summary>
        /// Заполняет одномернный массив случайными числа
        /// </summary>
        /// <param name="count">Размера одномерного массива</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <returns>Заполненный одномернный массив случайными числами</returns>
        public static int[] Init(int count, int min = 2, int max = 14)
        {
            int[] array = new int[count];
            Random rnd = new();
            for (int i = 0; i < array.Length; i++)
            {
                int random = rnd.Next(5, 10);
                array[i] = random;
            }
            return array;
        }
        /// <summary>
        /// Ищет сумму чисел > 5
        /// </summary>
        /// <param name="numbers">Одномернный массив</param>
        /// <returns>Сумму чисел > 5</returns>
        public static int SumMoreFive(this int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 5)
                {
                    sum += numbers[i];
                }
            }
            return sum;
        }
    }
}
