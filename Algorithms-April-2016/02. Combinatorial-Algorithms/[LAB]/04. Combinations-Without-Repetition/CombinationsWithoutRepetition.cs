namespace CombinationsWithoutRepetition
{
    using System;

    public class CombinationsWithoutRepetition
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[k];
            GenerateCombinations(arr, n, 0);
        }

        private static void GenerateCombinations(int[] arr, int n, int currentIndex, int startNum = 1)
        {
            if (currentIndex >= arr.Length)
            {
                Print(arr);
                return;
            }

            for (int num = startNum; num <= n; num++)
            {
                arr[currentIndex] = num;
                GenerateCombinations(arr, n, currentIndex + 1, num + 1);
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}