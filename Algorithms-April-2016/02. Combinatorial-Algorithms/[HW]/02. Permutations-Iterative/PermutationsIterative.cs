namespace PermutationsIterative
{
    using System;

    public class PermutationsIterative
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = InitializeArray(n);
            
            long nFactorial = GetNFactorial(n);

            int firstIndex = 0;
            int secondIndex = firstIndex + 1;
            int permutationsCount = 0;
            while (permutationsCount < nFactorial)
            {
                Swap(ref numbers[firstIndex], ref numbers[secondIndex]);
                Print(numbers);
                permutationsCount++;

                firstIndex++;
                secondIndex++;
                if (secondIndex >= n)
                {
                    firstIndex = 0;
                    secondIndex = 1;
                }
            }

            Console.WriteLine("Total permutations: " + permutationsCount);
        }

        private static int[] InitializeArray(int n)
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

        private static void Swap(ref int firstNum, ref int secondNum)
        {
            var swapValue = firstNum;
            firstNum = secondNum;
            secondNum = swapValue;
        }

        private static long GetNFactorial(int n)
        {
            long result = 1;
            for (int i = n; i >= 1; i--)
            {
                result *= i;
            }

            return result;
        }

        private static void Print(int[] numbers)
        {
            Console.WriteLine(string.Join("", numbers));
        }
    }
}