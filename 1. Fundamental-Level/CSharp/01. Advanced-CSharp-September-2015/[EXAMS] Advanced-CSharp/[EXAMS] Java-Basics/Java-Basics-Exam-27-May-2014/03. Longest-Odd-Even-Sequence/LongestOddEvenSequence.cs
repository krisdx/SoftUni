using System;
using System.Collections.Generic;
using System.Linq;

class LongestOddEvenSequence
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Trim().Split(new char[] { ' ', '\t', '(', ')' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int maxLength = GetSequenceWithFirstNumberOdd(numbers);

        Console.WriteLine(maxLength);
    }

    static int GetSequenceWithFirstNumberOdd(int[] numbers)
    {
        int maxLength = 1;

        for (int i = 0; i < numbers.Length; i++)
        {
            bool startsWithEven = false;
            if (numbers[i] % 2 != 0)
            {
                startsWithEven = true;
            }

            int currentLength = 1;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (!startsWithEven && (numbers[j] % 2 != 0 || numbers[j] == 0))
                {
                    startsWithEven = true;
                    currentLength++;
                }
                else if (startsWithEven && (numbers[j] % 2 == 0 || numbers[j] == 0))
                {
                    startsWithEven = false;
                    currentLength++;
                }
                else
                {
                    break;
                }
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
            }
        }

        return maxLength;
    }
}