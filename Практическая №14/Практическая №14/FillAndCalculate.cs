using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMatrix;

namespace Практическая__14
{
    public static class FillAndCalculate
    {
        public static void Fill(this Matrix<int> numbers, int rows, int column, int minValue, int maxValue)
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

        public static int[] Calculate(this Matrix<int> numbers)
        {
            int[] sum = new int[numbers.Columns];
            for (int i = 0; i < numbers.Rows; i++)
            {
                for (int j = 0; j < numbers.Columns; j += 2)
                {
                    sum[j] += numbers[i, j];
                }
            }
            return sum;
        }
    }
}
