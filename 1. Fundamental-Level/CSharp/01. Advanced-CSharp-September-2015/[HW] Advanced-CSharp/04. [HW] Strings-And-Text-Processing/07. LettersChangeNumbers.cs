using System;
using System.Linq;

class LettersChangeNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] sequences = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        decimal finalSum = 0;
        for (int i = 0; i < sequences.Length; i++)
        {
            string currentSequence = sequences[i];

            decimal currnetSum = 0;

            decimal number = GetNumber(currentSequence);
            char leftChar = currentSequence.First();
            char rightChar = currentSequence.Last();

            currnetSum = GetValue(leftChar, number, currnetSum);
            currnetSum = GetValue(number, rightChar, currnetSum);

            finalSum += currnetSum;
        }

        Console.WriteLine("{0:F2}", finalSum);
    }

    private static decimal GetValue(decimal number, char rightChar, decimal currentSum)
    {
        if (char.IsUpper(rightChar))
        {
            currentSum -= ((rightChar - 'A') + 1);
        }
        else
        {
            currentSum += ((rightChar - 'a') + 1);
        }

        return currentSum;
    }

    private static decimal GetValue(char leftChar, decimal number, decimal currentSum)
    {
        if (char.IsUpper(leftChar))
        {
            currentSum += number / ((leftChar - 'A') + 1);
        }
        else
        {
            currentSum += number * ((leftChar - 'a') + 1);
        }

        return currentSum;
    }

    private static decimal GetNumber(string currentSequence)
    {
        string numStr = string.Empty;
        for (int index = 1; index < currentSequence.Length - 1; index++)
        {
            numStr += currentSequence[index];
        }

        decimal num = decimal.Parse(numStr);

        return num;
    }
}