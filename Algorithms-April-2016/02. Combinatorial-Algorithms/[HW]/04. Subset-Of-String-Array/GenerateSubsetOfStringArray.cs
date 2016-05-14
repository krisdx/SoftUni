namespace GenerateSubsetOfStringArray
{
    using System;

    public class GenerateSubsetOfStringArray
    {
        private static string[] arr = { "test", "rock", "fun" };
        private static int k = 2;

        private static string[] resultArr = new string[k];

        public static void Main()
        {
            GetSubset();
        }

        private static void GetSubset(int startIndex = 0, int nextIndex = 0)
        {
            if (startIndex >= k)
            {
                Print(resultArr);
                return;
            }

            for (int currentIndex = nextIndex; currentIndex < arr.Length; currentIndex++)
            {
                resultArr[startIndex] = arr[currentIndex];
                GetSubset(startIndex + 1, currentIndex + 1);
            }
        }

        private static void Print(string[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}