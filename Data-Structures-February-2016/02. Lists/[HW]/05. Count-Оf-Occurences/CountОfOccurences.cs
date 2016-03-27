namespace CountОfOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountОfOccurences
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Trim()
                .Split()
                .Select(int.Parse)
                .ToList();

            var distinctedNumbers = numbers.Distinct();
            foreach (var number in distinctedNumbers)
            {
                var currentNumberOccurencesCount = numbers.Count(num => num == number);
                Console.WriteLine("{0} -> {1}", number, currentNumberOccurencesCount);
            }
        }
    }
}