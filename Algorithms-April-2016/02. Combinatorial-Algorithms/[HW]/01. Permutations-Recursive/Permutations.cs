namespace Permutations
{
    using System;

    public class Permutations
    {
        private static int permutationsCount;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = FillInitialArray(n);

            Permute(numbers);
            Console.WriteLine("Total permutations: " + permutationsCount);
        }

        private static int[] FillInitialArray(int n)
        {
            int[] arr = new int[n];

            int num = 1;
            for (int i = 0; i < n; i++)
            {
                arr[i] = num;
                num++;
            }

            return arr;
        }

        private static void Permute(int[] numbers, int startIndex = 0)
        {
            if (startIndex >= numbers.Length)
            {
                Print(numbers);
                permutationsCount++;
                return;
            }

            for (int currentIndex = startIndex; currentIndex < numbers.Length; currentIndex++)
            {
                Swap(ref numbers[startIndex], ref numbers[currentIndex]);
                Permute(numbers, startIndex + 1);
                Swap(ref numbers[startIndex], ref numbers[currentIndex]);
            }
        }

        private static void Swap(ref int firstNum, ref int secondNum)
        {
            var swapValue = firstNum;
            firstNum = secondNum;
            secondNum = swapValue;
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(string.Join("", arr));
        }
    }
}