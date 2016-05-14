namespace Generating_Combinations
{
    using System;

    public class CombinationsGenerator
    {
        private static int[] arr;

        public static void Main()
        {
            int n = 2;
            int startNum = 4;
            int endNum = 8;

            arr = new int[n];
            GenerateCombinations(0, startNum, endNum);
        }

        static void GenerateCombinations(int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                // A combination was found --> print it
                Console.WriteLine("({0})", string.Join(", ", arr));
                return;
            }

            for (int num = startNum; num <= endNum; num++)
            {
                arr[index] = num;
                GenerateCombinations(index + 1, num + 1, endNum);
            }
        }
    }
}