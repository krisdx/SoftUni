namespace Shuffling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Shuffling
    {
        private static Random randomGenerator = new Random();

        public static void Main()
        {
            var numbers = new List<int>() { 2, 3, 5, 1, 0, -9 };
            Console.WriteLine("Numbers: " + string.Join(" ", numbers));

            var shuffledNumbers = Shuffle(numbers);
            Console.WriteLine("Shuffled numbers: " + string.Join(" ", shuffledNumbers));
        }

        public static IEnumerable<int> Shuffle(IEnumerable<int> source)
        {

            var arr = source.ToArray();
            for (var currentIndex = 0; currentIndex < arr.Length; currentIndex++)
            {
                int randomIndex = currentIndex + randomGenerator.Next(0, arr.Length - currentIndex);
                Swap(arr, currentIndex, randomIndex);
            }

            return arr;
        }

        private static void Swap(int[] arr, int currentIndex, int randomIndex)
        {
            var swapValue = arr[currentIndex];
            arr[currentIndex] = arr[randomIndex];
            arr[randomIndex] = swapValue;
        }
    }
}