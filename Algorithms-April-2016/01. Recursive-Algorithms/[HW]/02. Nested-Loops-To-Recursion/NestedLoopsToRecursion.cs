namespace NestedLoopsToRecursion
{
    using System;

    public class NestedLoopsToRecursion
    {
        private static int N;
        private static int[] numbers;

        public static void Main()
        {
            Console.Write("N = ");
            N = int.Parse(Console.ReadLine());
            numbers = new int[N];

            NestedLoops(0);
        }

        private static void NestedLoops(int currentIndex)
        {
            if (currentIndex >= N)
            {
                Print();
                return;
            }

            for (int num = 1; num <= N; num++)
            {
                numbers[currentIndex] = num;
                NestedLoops(currentIndex + 1);
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