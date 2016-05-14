namespace ReverseArray
{
    using System;

    public class ReverseArray
    {
        public static void Main()
        {
            int[] sourceArr = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] reversedArr = new int[sourceArr.Length];

            ReverseArr(sourceArr, 0, reversedArr, sourceArr.Length - 1);
            Console.WriteLine("{0} -> {1}",
                string.Join(" ", sourceArr), string.Join(" ", reversedArr));
        }

        private static void ReverseArr(int[] sourceArr, int sourceIndex, int[] reversedArr, int reversedArrIndex)
        {
            if (sourceIndex >= sourceArr.Length)
            {
                return;
            }

            reversedArr[reversedArrIndex] = sourceArr[sourceIndex];
            ReverseArr(sourceArr, sourceIndex + 1, reversedArr, reversedArrIndex - 1);
        }
    }
}