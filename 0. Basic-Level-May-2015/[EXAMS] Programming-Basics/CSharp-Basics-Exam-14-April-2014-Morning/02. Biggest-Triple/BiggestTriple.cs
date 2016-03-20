using System;
using System.Linq;

class BiggestTriple
{
    static void Main()
    {
        string inputNumbers = Console.ReadLine();
        int[] numbers = inputNumbers.Split(' ').Select(int.Parse).ToArray();

        int index = 0;
        int maxSum = int.MinValue;
        int printDigitIndex = 0;
        while (index < numbers.Length)
        {
            int num1 = numbers[index];

            int num2 = 0;
            if (index + 1 < numbers.Length)
            {
                num2 = numbers[index + 1];
            }

            int num3 = 0;
            if (index + 2 < numbers.Length)
            {
                num3 = numbers[index + 2];
            }

            int currentSum = num1 + num2 + num3;
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                printDigitIndex = index;
            }

            index += 3;
        }

        while (maxSum != 0)
        {
            Console.Write(numbers[printDigitIndex]);
            maxSum -= numbers[printDigitIndex];
            if (maxSum != 0)
            {
                Console.Write(" ");
            }
            printDigitIndex++;
        }
    }
}