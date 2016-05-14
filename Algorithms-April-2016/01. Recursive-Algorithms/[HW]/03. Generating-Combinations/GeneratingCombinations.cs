namespace GeneratingCombinations
{
    using System;

    public class GeneratingCombinations
    {
        private static int N;
        private static int K;
        private static int[] numbers;

        private static int totalCombinations;

        public static void Main()
        {
            Console.Write("N = ");
            N = int.Parse(Console.ReadLine());

            Console.Write("K = ");
            K = int.Parse(Console.ReadLine());

            numbers = new int[K];

            GenerateCombinations(0, 1);
            Console.WriteLine("Total number of combinations: " + totalCombinations);
        }

        private static void GenerateCombinations(int currentIndex, int currentNum)
        {
            if (K == currentIndex)
            {
                totalCombinations++;
                Print();
                return;
            }

            for (int num = currentNum; num <= N; num++)
            {
                numbers[currentIndex] = num;
                GenerateCombinations(currentIndex + 1, num);
            }
        }

        private static void Print()
        {
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
        }
    }
}