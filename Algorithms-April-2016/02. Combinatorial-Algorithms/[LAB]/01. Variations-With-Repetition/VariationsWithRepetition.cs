namespace VariationsWithRepetition
{
    using System;

    public class VariationsWithRepetition
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[k];
            GenerateVariations(arr, n, 0);
        }

        private static void GenerateVariations(int[] arr, int n, int currentIndex)
        {
            if (currentIndex >= arr.Length)
            {
                Print(arr);
                return;
            }

            for (int num = 1; num <= n; num++)
            {
                arr[currentIndex] = num;
                GenerateVariations(arr, n, currentIndex + 1);
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}