namespace RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveOddOccurencesMain
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Trim()
                .Split()
                .Select(int.Parse)
                .ToList();

            var newList = RemoveOddOccurences(numbers);
            Console.WriteLine(string.Join(" ", newList));
        }

        private static List<int> RemoveOddOccurences(List<int> numbers)
        {
            var copyList = numbers.ToList();

            foreach (int number in numbers)
            {
                int currentNumberOccurrencesCount = numbers.Count(num => num == number);
                if (currentNumberOccurrencesCount % 2 == 1)
                {
                    copyList.RemoveAll(num => num == number);
                }
            }

            return copyList;
        }
    }
}