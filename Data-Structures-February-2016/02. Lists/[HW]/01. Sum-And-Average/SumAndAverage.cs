namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAndAverage
    {
        public static void Main()
        {
            try
            {
                List<int> numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                Console.WriteLine("Sum={0}; Average={1}", Sum(numbers), Average(numbers));
            }
            catch (Exception)
            {
                Console.WriteLine("Sum=0; Average=0");
            }
        }

        private static double Average(List<int> numbers)
        {
            long sum = Sum(numbers);
            double average = (double)sum / numbers.Count;

            return average;
        }

        private static long Sum(List<int> numbers)
        {
            long sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }
    }
}