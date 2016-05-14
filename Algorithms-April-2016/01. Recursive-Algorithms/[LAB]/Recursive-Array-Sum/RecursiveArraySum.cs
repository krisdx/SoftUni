namespace RecursiveArraySum
{
    using System;

    public class RecursiveArraySum
    {
        public static void Main()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };

            long sum = FindSum(arr, 0);
            Console.WriteLine(sum);
        }

        private static long FindSum(int[] arr, int currentIndex)
        {
            if (currentIndex == arr.Length - 1)
            {
                return arr[currentIndex];
            }

            long currentNum = arr[currentIndex];
            return currentNum + FindSum(arr, currentIndex + 1);
        }
    }
}