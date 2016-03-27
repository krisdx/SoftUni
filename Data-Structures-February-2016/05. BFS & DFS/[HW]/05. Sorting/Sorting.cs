namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sorting
    {
        private static List<int> numbers;
        private static int consecutiveNumbers;

        public static void Main()
        {
            ReadInput();

            int numberOfPermutations = GetMinNumberOfPermutations();
            Console.WriteLine(numberOfPermutations);
        }

        private static int GetMinNumberOfPermutations()
        {
            var queue = new Queue<Sequence>();
            var uniqueSequences = new HashSet<string> { string.Join(", ", numbers) };

            queue.Enqueue(new Sequence(numbers));
            while (queue.Count > 0)
            {
                var currentSequence = queue.Dequeue();
                if (IsSorted(currentSequence.Numbers))
                {
                    return currentSequence.PermutationsCount;
                }

                int numberOfPermutations = currentSequence.Numbers.Count - (consecutiveNumbers - 1);
                for (int index = 0; index < numberOfPermutations; index++)
                {
                    var reversedSequence = Reverse(currentSequence.Numbers, index, consecutiveNumbers);

                    var reversedSequenceToStrng = string.Join(", ", reversedSequence);
                    if (!uniqueSequences.Contains(reversedSequenceToStrng))
                    {
                        uniqueSequences.Add(reversedSequenceToStrng);

                        var newSequence = new Sequence(reversedSequence, currentSequence.PermutationsCount + 1);
                        queue.Enqueue(newSequence);
                    }
                }
            }

            return -1;
        }

        private static void ReadInput()
        {
            int numbersCount = int.Parse(Console.ReadLine());
            numbers = Console.ReadLine().Trim()
                            .Split()
                            .Select(int.Parse)
                            .ToList();

            numbers.Capacity = numbersCount;

            consecutiveNumbers = int.Parse(Console.ReadLine());
        }

        private static bool IsSorted(IList<int> sequence)
        {
            var currentNum = sequence[0];

            for (int i = 1; i < sequence.Count; i++)
            {
                if (currentNum > sequence[i])
                {
                    return false;
                }

                currentNum = sequence[i];
            }

            return true;
        }

        private static List<int> Reverse(IList<int> currentSequence, int startIndex, int count)
        {
            var reversedNumbers = new List<int>(currentSequence);

            reversedNumbers.Reverse(startIndex, count);

            return reversedNumbers;
        }
    }
}