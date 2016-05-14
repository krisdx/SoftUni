namespace VariationsWithoutRepetition
{
    using System;

    public class VariationsWithoutRepetition
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[k];
            bool[] used = new bool[n + 1];

            GenerateVariations(arr, n, used, 0);
        }

        private static void GenerateVariations(int[] arr, int n, bool[] used, int currentIndex)
        {
            if (currentIndex >= arr.Length)
            {
                Print(arr);
                return;
            }

            for (int num = 1; num <= n; num++)
            {
                if (!used[num])
                {
                    used[num] = true;
                    arr[currentIndex] = num;
                    GenerateVariations(arr, n, used, currentIndex + 1);
                    used[num] = false;
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}