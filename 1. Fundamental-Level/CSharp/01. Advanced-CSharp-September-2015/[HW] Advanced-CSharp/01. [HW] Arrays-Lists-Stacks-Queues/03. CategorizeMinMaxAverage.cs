using System;
using System.Collections.Generic;
using System.Linq;

// Write a program that reads N floating-point numbers from the console. Your task is to separate them in two sets, one containing only the round numbers (e.g. 1, 1.00, etc.) and the other containing the floating-point numbers with non-zero fraction. Print both arrays along with their minimum, maximum, sum and average (rounded to two decimal places). 

class CategorizeMinMaxAverage
{
    static void Main()
    {
        double[] numbers = Console.ReadLine().Trim().Split().Select(double.Parse).ToArray();

        List<int> integerNumbers = new List<int>();
        List<double> floatingPointNumbers = new List<double>();
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 1 == 0)
            {
                integerNumbers.Add(Convert.ToInt32(numbers[i]));
            }
            else
            {
                floatingPointNumbers.Add(numbers[i]);
            }
        }

        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}", string.Join(", ", floatingPointNumbers), floatingPointNumbers.Min(), floatingPointNumbers.Max(), floatingPointNumbers.Sum(), floatingPointNumbers.Average());

        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}", string.Join(", ", integerNumbers), integerNumbers.Min(), integerNumbers.Max(), integerNumbers.Sum(), floatingPointNumbers.Average());
    }
}